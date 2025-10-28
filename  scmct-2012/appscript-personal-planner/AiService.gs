/**
 * Retrieves AI configuration from Script Properties.
 * @return {{endpoint: string|null, apiKey: string|null}}
 */
function getAiConfig() {
  const props = PropertiesService.getScriptProperties();
  return {
    endpoint: props.getProperty('AI_ENDPOINT') || null,
    apiKey: props.getProperty('AI_API_KEY') || null
  };
}

/**
 * Calls an external AI endpoint if configured, otherwise falls back to a built-in helper.
 * @param {string} action
 * @param {Object} payload
 * @return {Object}
 */
function callAi(action, payload) {
  const config = getAiConfig();
  if (config.endpoint && config.apiKey) {
    try {
      const response = UrlFetchApp.fetch(config.endpoint, {
        method: 'post',
        contentType: 'application/json',
        headers: {
          Authorization: 'Bearer ' + config.apiKey
        },
        payload: JSON.stringify({ action: action, payload: payload })
      });
      const text = response.getContentText();
      return JSON.parse(text);
    } catch (error) {
      console.warn('AI endpoint call failed, falling back to local helper.', error);
    }
  }

  return fallbackAi(action, payload);
}

/**
 * Provides a deterministic fallback implementation when no AI endpoint is configured.
 * @param {string} action
 * @param {Object} payload
 * @return {Object}
 */
function fallbackAi(action, payload) {
  if (action === 'plan_suggestions') {
    return {
      suggestions: buildFallbackPlanSuggestions(payload.prompt, payload.date)
    };
  }

  if (action === 'search_plans') {
    return {
      matches: buildFallbackPlanSearch(payload.query, payload.plans)
    };
  }

  return {};
}

/**
 * Generates simple plan suggestions from a prompt.
 * @param {string} prompt
 * @param {string} date
 * @return {Array<Object>}
 */
function buildFallbackPlanSuggestions(prompt, date) {
  var suggestions = [];
  if (!prompt) {
    return suggestions;
  }

  var lines = prompt.split(/\r?\n/);
  lines.forEach(function (line) {
    var cleaned = cleanText(line);
    if (!cleaned) {
      return;
    }

    var timeMatch = cleaned.match(/(\d{1,2}[:h]\d{2})/i);
    var title = cleaned;
    var time = '';
    if (timeMatch) {
      time = timeMatch[1]
        .replace('h', ':')
        .replace('.', ':');
      title = cleaned.replace(timeMatch[1], '').trim();
    }

    if (!title) {
      title = 'Công việc';
    }

    suggestions.push({
      date: normalizeIsoDate(date) || normalizeIsoDate(new Date()),
      time: time || '',
      title: titleCase(title),
      description: '',
      tags: ''
    });
  });

  if (!suggestions.length && prompt) {
    suggestions.push({
      date: normalizeIsoDate(date) || normalizeIsoDate(new Date()),
      time: '',
      title: titleCase(prompt.slice(0, 60)),
      description: '',
      tags: ''
    });
  }

  return suggestions;
}

/**
 * Performs a basic keyword search over plans.
 * @param {string} query
 * @param {Array<Object>} plans
 * @return {Array<Object>}
 */
function buildFallbackPlanSearch(query, plans) {
  var cleanedQuery = cleanText(query).toLowerCase();
  if (!cleanedQuery) {
    return plans;
  }

  return plans.filter(function (plan) {
    var haystack = [plan.title, plan.description, plan.tags]
      .filter(function (value) {
        return value;
      })
      .join(' ')
      .toLowerCase();

    return haystack.indexOf(cleanedQuery) !== -1;
  });
}

/**
 * Returns AI generated plan suggestions for the UI.
 * @param {string} prompt
 * @param {string} date
 * @return {Array<Object>}
 */
function getAiPlanSuggestions(prompt, date) {
  const result = callAi('plan_suggestions', { prompt: prompt, date: date });
  return (result && result.suggestions) || [];
}

/**
 * Returns AI assisted search matches for existing plans.
 * @param {string} query
 * @return {Array<Object>}
 */
function getAiSearchMatches(query) {
  const plans = getUpcomingPlans();
  const result = callAi('search_plans', { query: query, plans: plans });
  return (result && result.matches) || [];
}
