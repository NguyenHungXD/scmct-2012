/**
 * Entry point for the web application.
 * @return {GoogleAppsScript.HTML.HtmlOutput}
 */
function doGet() {
  return HtmlService.createTemplateFromFile('Main')
    .evaluate()
    .setTitle('Personal Planner AI');
}

/**
 * Helper to include partial HTML files.
 * @param {string} filename
 * @return {string}
 */
function include(filename) {
  return HtmlService.createHtmlOutputFromFile(filename).getContent();
}

function apiGetCalendar(year, month) {
  return getCalendarData(year, month);
}

function apiGetPlansForDay(isoDate) {
  return getPlansForDay(isoDate);
}

function apiSavePlan(plan) {
  return savePlanAndRefresh(plan);
}

function apiDeletePlan(id, year, month) {
  return deletePlanAndRefresh(id, year, month);
}

function apiGetUpcomingPlans() {
  return getUpcomingDashboardPlans();
}

function apiGetAiSuggestions(prompt, date) {
  return getAiPlanSuggestions(prompt, date);
}

function apiSearchPlans(query) {
  return getAiSearchMatches(query);
}
