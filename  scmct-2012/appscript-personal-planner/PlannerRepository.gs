const PLANNER_SHEET_NAME = 'Plans';
const PLANNER_HEADERS = [
  'ID',
  'Date',
  'Time',
  'Title',
  'Description',
  'Tags',
  'Status',
  'CreatedAt',
  'UpdatedAt'
];

/**
 * Returns the spreadsheet that stores the planner data.
 * The spreadsheet id is cached in Script Properties so it persists across deployments.
 * @return {GoogleAppsScript.Spreadsheet.Sheet}
 */
function getPlannerSheet() {
  const scriptProperties = PropertiesService.getScriptProperties();
  let spreadsheetId = scriptProperties.getProperty('PLANNER_SHEET_ID');
  let spreadsheet;

  if (spreadsheetId) {
    try {
      spreadsheet = SpreadsheetApp.openById(spreadsheetId);
    } catch (error) {
      console.warn('Existing spreadsheet could not be opened. Creating a new one.', error);
    }
  }

  if (!spreadsheet) {
    spreadsheet = SpreadsheetApp.create('Personal Planner Data');
    spreadsheetId = spreadsheet.getId();
    scriptProperties.setProperty('PLANNER_SHEET_ID', spreadsheetId);
  }

  let sheet = spreadsheet.getSheetByName(PLANNER_SHEET_NAME);
  if (!sheet) {
    sheet = spreadsheet.insertSheet(PLANNER_SHEET_NAME);
  }

  const headerRange = sheet.getRange(1, 1, 1, PLANNER_HEADERS.length);
  const headerValues = headerRange.getValues()[0];
  const needsHeaders = PLANNER_HEADERS.some(function (header, index) {
    return headerValues[index] !== header;
  });

  if (needsHeaders) {
    headerRange.setValues([PLANNER_HEADERS]);
  }

  return sheet;
}

/**
 * Converts a row array into a planner item object.
 * @param {Array<*>} row
 * @return {Object}
 */
function rowToPlan(row) {
  return {
    id: row[0],
    date: row[1],
    time: row[2],
    title: row[3],
    description: row[4],
    tags: row[5],
    status: row[6],
    createdAt: row[7],
    updatedAt: row[8]
  };
}

/**
 * Fetches all plans from the storage sheet.
 * @return {Array<Object>}
 */
function getAllPlans() {
  const sheet = getPlannerSheet();
  const lastRow = sheet.getLastRow();
  if (lastRow < 2) {
    return [];
  }

  const range = sheet.getRange(2, 1, lastRow - 1, PLANNER_HEADERS.length);
  const values = range.getValues();
  return values
    .filter(function (row) {
      return row[0];
    })
    .map(rowToPlan);
}

/**
 * Persists a plan. Creates a new row if no id exists yet.
 * @param {Object} plan
 * @return {Object}
 */
function savePlan(plan) {
  const sheet = getPlannerSheet();
  const now = new Date().toISOString();

  if (!plan.id) {
    plan.id = Utilities.getUuid();
    plan.createdAt = now;
  }

  plan.updatedAt = now;
  const normalized = normalizePlan(plan);

  const existingRow = findRowById(sheet, plan.id);
  const rowValues = [
    normalized.id,
    normalized.date,
    normalized.time,
    normalized.title,
    normalized.description,
    normalized.tags,
    normalized.status,
    normalized.createdAt,
    normalized.updatedAt
  ];

  if (existingRow) {
    sheet.getRange(existingRow, 1, 1, PLANNER_HEADERS.length).setValues([rowValues]);
  } else {
    sheet.appendRow(rowValues);
  }

  return normalized;
}

/**
 * Removes a plan by id.
 * @param {string} id
 * @return {boolean}
 */
function deletePlan(id) {
  if (!id) {
    return false;
  }

  const sheet = getPlannerSheet();
  const row = findRowById(sheet, id);
  if (!row) {
    return false;
  }

  sheet.deleteRow(row);
  return true;
}

/**
 * Finds a single plan by id.
 * @param {string} id
 * @return {Object|null}
 */
function getPlanById(id) {
  const sheet = getPlannerSheet();
  const row = findRowById(sheet, id);
  if (!row) {
    return null;
  }

  const values = sheet.getRange(row, 1, 1, PLANNER_HEADERS.length).getValues()[0];
  return rowToPlan(values);
}

/**
 * Gets plans that occur on a specific ISO date.
 * @param {string} isoDate
 * @return {Array<Object>}
 */
function getPlansForDate(isoDate) {
  if (!isoDate) {
    return [];
  }

  return getAllPlans().filter(function (plan) {
    return plan.date === isoDate;
  });
}

/**
 * Gets upcoming plans starting today.
 * @param {number} limit
 * @return {Array<Object>}
 */
function getUpcomingPlans(limit) {
  var plans = getAllPlans();
  const todayIso = toIsoDate(new Date());
  plans = plans.filter(function (plan) {
    return plan.date >= todayIso;
  });

  plans.sort(function (a, b) {
    if (a.date === b.date) {
      return (a.time || '').localeCompare(b.time || '');
    }
    return a.date.localeCompare(b.date);
  });

  if (limit && limit > 0) {
    plans = plans.slice(0, limit);
  }

  return plans;
}

/**
 * Finds sheet row index for id.
 * @param {GoogleAppsScript.Spreadsheet.Sheet} sheet
 * @param {string} id
 * @return {number|null}
 */
function findRowById(sheet, id) {
  const lastRow = sheet.getLastRow();
  if (lastRow < 2) {
    return null;
  }

  const range = sheet.getRange(2, 1, lastRow - 1, 1);
  const values = range.getValues();
  for (var index = 0; index < values.length; index++) {
    if (values[index][0] === id) {
      return index + 2;
    }
  }

  return null;
}

/**
 * Normalises plan data to ensure consistent formatting.
 * @param {Object} plan
 * @return {Object}
 */
function normalizePlan(plan) {
  const normalized = Object.assign(
    {
      id: null,
      date: null,
      time: '',
      title: '',
      description: '',
      tags: '',
      status: 'Planned',
      createdAt: null,
      updatedAt: null
    },
    plan
  );

  if (normalized.date) {
    normalized.date = normalized.date.slice(0, 10);
  }

  if (normalized.time) {
    normalized.time = normalized.time.slice(0, 5);
  }

  if (normalized.tags && Array.isArray(normalized.tags)) {
    normalized.tags = normalized.tags.join(', ');
  }

  return normalized;
}
