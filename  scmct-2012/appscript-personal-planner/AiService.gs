/**
 * Retrieves AI configuration from persisted settings.
 * @return {{apiKey: string|null, model: string}}
 */
function getAiConfig() {
  const apiKey = getSettingValue('GEMINI_API_KEY', '');
  const model = getSettingValue('GEMINI_MODEL', 'gemini-pro');
  return {
    apiKey: apiKey || null,
    model: cleanText(model) || 'gemini-pro'
  };
}

/**
 * Calls Gemini if configured, otherwise falls back to deterministic helpers.
 * @param {string} action
 * @param {Object} payload
 * @return {Object}
 */
function callAi(action, payload) {
  const config = getAiConfig();
  if (config.apiKey) {
    try {
      const result = callGemini(action, payload, config);
      if (result) {
        return result;
      }
    } catch (error) {
      console.warn('Gemini call failed, using fallback AI.', error);
    }
  }

  return fallbackAi(action, payload);
}

/**
 * Calls Gemini to complete a specific action.
 * @param {string} action
 * @param {Object} payload
 * @param {{apiKey: string, model: string}} config
 * @return {Object|null}
 */
function callGemini(action, payload, config) {
  payload = payload || {};
  const prompt = buildGeminiPrompt(action, payload);
  if (!prompt) {
    return null;
  }

  const requestBody = {
    contents: [
      {
        role: 'user',
        parts: [{ text: prompt }]
      }
    ],
    generationConfig: {
      temperature: 0.25,
      topP: 0.9,
      maxOutputTokens: 600
    }
  };

  const url =
    'https://generativelanguage.googleapis.com/v1beta/models/' +
    encodeURIComponent(config.model) +
    ':generateContent?key=' +
    encodeURIComponent(config.apiKey);

  const response = UrlFetchApp.fetch(url, {
    method: 'post',
    contentType: 'application/json',
    muteHttpExceptions: true,
    payload: JSON.stringify(requestBody)
  });

  if (response.getResponseCode() >= 300) {
    throw new Error('Gemini API error: ' + response.getContentText());
  }

  const result = JSON.parse(response.getContentText());
  const text = extractGeminiText(result);
  if (!text) {
    return null;
  }

  const parsed = parseGeminiStructuredJson(text);
  if (!parsed) {
    return null;
  }

  if (action === 'plan_suggestions' && parsed.suggestions) {
    return parsed;
  }

  if (action === 'search_plans' && parsed.matches) {
    const plans = payload && payload.plans ? payload.plans : [];
    const parsedMatches = Array.isArray(parsed.matches) ? parsed.matches : [parsed.matches];
    if (parsedMatches.length && typeof parsedMatches[0] === 'object') {
      return { matches: parsedMatches };
    }
    const matches = parsedMatches
      .map(function (matchId) {
        return plans.find(function (plan) {
          return plan.id === matchId;
        });
      })
      .filter(function (plan) {
        return plan;
      });
    return { matches: matches };
  }

  return null;
}

/**
 * Builds a detailed prompt for Gemini based on the action.
 * @param {string} action
 * @param {Object} payload
 * @return {string}
 */
function buildGeminiPrompt(action, payload) {
  if (action === 'plan_suggestions') {
    var isoDate = normalizeIsoDate(payload.date) || normalizeIsoDate(new Date());
    return [
      'Bạn là trợ lý lập kế hoạch cá nhân.',
      'Hãy tạo gợi ý kế hoạch dựa trên nội dung người dùng cung cấp.',
      'Trả về đối tượng JSON với cấu trúc {"suggestions": [{"date","time","title","description","tags"}]}.',
      'Luôn dùng định dạng thời gian HH:mm và tiếng Việt tự nhiên.',
      'Nếu không chắc chắn về giờ, để trống chuỗi.',
      'Ngày mục tiêu: ' + isoDate + '.',
      'Văn bản người dùng:',
      '"""' + (payload.prompt || '') + '"""'
    ].join('\n');
  }

  if (action === 'search_plans') {
    const plans = (payload && payload.plans) || [];
    const serializedPlans = JSON.stringify(
      plans.map(function (plan) {
        return {
          id: plan.id,
          date: plan.date,
          time: plan.time,
          title: plan.title,
          description: plan.description,
          tags: plan.tags
        };
      })
    );
    return [
      'Bạn là trợ lý tìm kiếm lịch cá nhân.',
      'Hãy xác định kế hoạch phù hợp với truy vấn người dùng.',
      'Trả về đối tượng JSON với cấu trúc {"matches": ["planId", ...]}.',
      'Truy vấn: ' + (payload.query || ''),
      'Danh sách kế hoạch dạng JSON:',
      serializedPlans
    ].join('\n');
  }

  return '';
}

/**
 * Extracts the primary text content from a Gemini response.
 * @param {Object} response
 * @return {string}
 */
function extractGeminiText(response) {
  if (!response || !response.candidates || !response.candidates.length) {
    return '';
  }

  const candidate = response.candidates[0];
  if (candidate && candidate.content && candidate.content.parts) {
    return candidate.content.parts
      .map(function (part) {
        return part.text || '';
      })
      .join('\n')
      .trim();
  }

  if (candidate && candidate.output && candidate.output[0]) {
    return cleanText(candidate.output[0]);
  }

  return '';
}

/**
 * Attempts to parse a JSON object from Gemini text output.
 * @param {string} text
 * @return {Object|null}
 */
function parseGeminiStructuredJson(text) {
  if (!text) {
    return null;
  }

  var cleaned = text.trim();
  cleaned = cleaned.replace(/```json/gi, '```');
  cleaned = cleaned.replace(/```/g, '');

  try {
    return JSON.parse(cleaned);
  } catch (error) {
    var firstBrace = cleaned.indexOf('{');
    var lastBrace = cleaned.lastIndexOf('}');
    if (firstBrace !== -1 && lastBrace !== -1 && lastBrace > firstBrace) {
      try {
        return JSON.parse(cleaned.slice(firstBrace, lastBrace + 1));
      } catch (ignored) {
        return null;
      }
    }
    return null;
  }
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
