/**
 * Builds a calendar grid for the UI.
 * @param {number} year
 * @param {number} month One-based month number
 * @return {Object}
 */
function getCalendarData(year, month) {
  const baseDate = new Date(year, month - 1, 1);
  const plans = getAllPlans();
  const countIndex = buildPlanCountIndex(plans);

  const start = new Date(baseDate);
  start.setDate(1);
  const startDay = start.getDay();
  start.setDate(start.getDate() - startDay);

  const days = [];
  for (var offset = 0; offset < 42; offset++) {
    const current = new Date(start);
    current.setDate(start.getDate() + offset);
    const iso = toIsoDate(current);
    days.push({
      date: iso,
      day: current.getDate(),
      inMonth: current.getMonth() === baseDate.getMonth(),
      isToday: iso === toIsoDate(new Date()),
      count: countIndex[iso] || 0
    });
  }

  return {
    days: days,
    label: Utilities.formatDate(baseDate, Session.getScriptTimeZone(), 'MMMM yyyy'),
    month: month,
    year: year
  };
}

/**
 * Returns detailed plans for a specific day.
 * @param {string} isoDate
 * @return {Array<Object>}
 */
function getPlansForDay(isoDate) {
  const plans = getPlansForDate(isoDate);
  plans.sort(function (a, b) {
    if (a.time === b.time) {
      return a.title.localeCompare(b.title);
    }
    return (a.time || '').localeCompare(b.time || '');
  });
  return plans;
}

/**
 * Saves a plan and returns the updated calendar for the plan's month.
 * @param {Object} plan
 * @return {{plan: Object, calendar: Object}}
 */
function savePlanAndRefresh(plan) {
  plan.date = normalizeIsoDate(plan.date);
  plan.time = cleanText(plan.time);
  plan.title = cleanText(plan.title);
  plan.description = cleanText(plan.description);
  plan.tags = normalizeTags(plan.tags);
  plan.status = plan.status || 'Planned';

  const saved = savePlan(plan);
  const date = new Date(saved.date + 'T00:00:00');
  const calendar = getCalendarData(date.getFullYear(), date.getMonth() + 1);

  return {
    plan: saved,
    calendar: calendar,
    dayPlans: getPlansForDay(saved.date)
  };
}

/**
 * Deletes a plan and returns refreshed calendar information.
 * @param {string} id
 * @param {number} year
 * @param {number} month
 * @return {{success: boolean, calendar: Object}}
 */
function deletePlanAndRefresh(id, year, month) {
  const success = deletePlan(id);
  const calendar = getCalendarData(year, month);
  return {
    success: success,
    calendar: calendar
  };
}

/**
 * Returns the next upcoming plans for the dashboard.
 * @return {Array<Object>}
 */
function getUpcomingDashboardPlans() {
  return getUpcomingPlans(10);
}
