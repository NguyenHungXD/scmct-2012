/**
 * Formats a Date into ISO date (yyyy-MM-dd) string.
 * @param {Date} date
 * @return {string}
 */
function toIsoDate(date) {
  if (!date) {
    return '';
  }
  return Utilities.formatDate(date, Session.getScriptTimeZone(), 'yyyy-MM-dd');
}

/**
 * Parses a date string or Date into ISO date.
 * @param {string|Date} value
 * @return {string}
 */
function normalizeIsoDate(value) {
  if (!value) {
    return '';
  }
  if (Object.prototype.toString.call(value) === '[object Date]') {
    return toIsoDate(value);
  }
  var parsed = new Date(value);
  if (isNaN(parsed.getTime())) {
    return '';
  }
  return toIsoDate(parsed);
}

/**
 * Capitalises the first letter of every word.
 * @param {string} value
 * @return {string}
 */
function titleCase(value) {
  if (!value) {
    return '';
  }
  return value.replace(/\w\S*/g, function (text) {
    return text.charAt(0).toUpperCase() + text.substr(1).toLowerCase();
  });
}

/**
 * Ensures text is a trimmed string.
 * @param {string} value
 * @return {string}
 */
function cleanText(value) {
  if (!value) {
    return '';
  }
  return String(value).trim();
}

/**
 * Creates a safe HTML representation of text for server responses.
 * @param {string} value
 * @return {string}
 */
function escapeHtml(value) {
  if (!value) {
    return '';
  }
  return String(value)
    .replace(/&/g, '&amp;')
    .replace(/</g, '&lt;')
    .replace(/>/g, '&gt;')
    .replace(/"/g, '&quot;')
    .replace(/'/g, '&#39;');
}

/**
 * Creates a consistent tag string from array or comma separated values.
 * @param {string|Array<string>} tags
 * @return {string}
 */
function normalizeTags(tags) {
  if (!tags) {
    return '';
  }

  if (Array.isArray(tags)) {
    return tags
      .map(function (tag) {
        return cleanText(tag);
      })
      .filter(function (tag) {
        return tag.length;
      })
      .join(', ');
  }

  return tags
    .split(',')
    .map(function (tag) {
      return cleanText(tag);
    })
    .filter(function (tag) {
      return tag.length;
    })
    .join(', ');
}

/**
 * Creates an index of plan counts by ISO date for quick lookups.
 * @param {Array<Object>} plans
 * @return {Object<string, number>}
 */
function buildPlanCountIndex(plans) {
  return plans.reduce(function (accumulator, plan) {
    if (!plan.date) {
      return accumulator;
    }
    if (!accumulator[plan.date]) {
      accumulator[plan.date] = 0;
    }
    accumulator[plan.date] += 1;
    return accumulator;
  }, {});
}
