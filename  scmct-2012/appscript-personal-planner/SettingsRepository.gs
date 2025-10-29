const SETTINGS_SHEET_NAME = 'Settings';
const SETTINGS_HEADERS = ['Key', 'Value'];

/**
 * Returns the settings sheet that stores configuration data.
 * Ensures the sheet and headers exist in the same spreadsheet as plans.
 * @return {GoogleAppsScript.Spreadsheet.Sheet}
 */
function getSettingsSheet() {
  const plannerSheet = getPlannerSheet();
  const spreadsheet = plannerSheet.getParent();
  let sheet = spreadsheet.getSheetByName(SETTINGS_SHEET_NAME);
  if (!sheet) {
    sheet = spreadsheet.insertSheet(SETTINGS_SHEET_NAME);
  }

  const headerRange = sheet.getRange(1, 1, 1, SETTINGS_HEADERS.length);
  const values = headerRange.getValues()[0];
  const needsHeaders = SETTINGS_HEADERS.some(function (header, index) {
    return values[index] !== header;
  });

  if (needsHeaders) {
    headerRange.setValues([SETTINGS_HEADERS]);
  }

  return sheet;
}

/**
 * Reads all settings rows into a key/value map.
 * @return {Object<string, string>}
 */
function getAllSettings() {
  const sheet = getSettingsSheet();
  const lastRow = sheet.getLastRow();
  if (lastRow < 2) {
    return {};
  }

  const range = sheet.getRange(2, 1, lastRow - 1, SETTINGS_HEADERS.length);
  const rows = range.getValues();
  return rows.reduce(function (accumulator, row) {
    const key = cleanText(row[0]);
    if (!key) {
      return accumulator;
    }
    accumulator[key] = cleanText(row[1]);
    return accumulator;
  }, {});
}

/**
 * Returns an individual setting value with a default fallback.
 * @param {string} key
 * @param {string=} defaultValue
 * @return {string}
 */
function getSettingValue(key, defaultValue) {
  const settings = getAllSettings();
  if (Object.prototype.hasOwnProperty.call(settings, key)) {
    return settings[key];
  }
  return defaultValue || '';
}

/**
 * Persists or updates a single setting value.
 * @param {string} key
 * @param {string} value
 * @return {{key: string, value: string}}
 */
function setSettingValue(key, value) {
  const normalizedKey = cleanText(key);
  const normalizedValue = value === null || value === undefined ? '' : cleanText(value);
  if (!normalizedKey) {
    throw new Error('Setting key is required.');
  }

  const sheet = getSettingsSheet();
  const lastRow = sheet.getLastRow();
  let rowIndex = null;

  if (lastRow >= 2) {
    const existingKeys = sheet.getRange(2, 1, lastRow - 1, 1).getValues();
    for (var index = 0; index < existingKeys.length; index++) {
      if (existingKeys[index][0] === normalizedKey) {
        rowIndex = index + 2;
        break;
      }
    }
  }

  const rowValues = [[normalizedKey, normalizedValue]];

  if (rowIndex) {
    sheet.getRange(rowIndex, 1, 1, SETTINGS_HEADERS.length).setValues(rowValues);
  } else {
    sheet.appendRow(rowValues[0]);
  }

  return { key: normalizedKey, value: normalizedValue };
}

/**
 * Saves supported settings from the client and returns the updated values.
 * @param {{geminiApiKey: string, geminiModel: string}} settings
 * @return {{geminiApiKey: string, geminiModel: string}}
 */
function saveSettingsForClient(settings) {
  const payload = settings || {};
  const apiKey = cleanText(payload.geminiApiKey);
  const model = cleanText(payload.geminiModel) || 'gemini-pro';

  setSettingValue('GEMINI_API_KEY', apiKey);
  setSettingValue('GEMINI_MODEL', model);

  return {
    geminiApiKey: apiKey,
    geminiModel: model
  };
}

/**
 * Returns settings formatted for the client UI.
 * @return {{geminiApiKey: string, geminiModel: string}}
 */
function getSettingsForClient() {
  return {
    geminiApiKey: getSettingValue('GEMINI_API_KEY', ''),
    geminiModel: getSettingValue('GEMINI_MODEL', 'gemini-pro')
  };
}
