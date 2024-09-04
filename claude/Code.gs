function doGet() {
  return HtmlService.createHtmlOutputFromFile('Index')
      .setTitle('Claude Chat')
      .setXFrameOptionsMode(HtmlService.XFrameOptionsMode.ALLOWALL);
}

function callClaudeApi(apiKey, message) {
  var url = 'https://api.anthropic.com/v1/messages';
  var headers = {
    'Content-Type': 'application/json',
    'x-api-key': apiKey,
    'anthropic-version': '2023-06-01'
  };
  var payload = {
    'model': 'claude-3-sonnet-20240229',
    'max_tokens': 1000,
    'messages': [{'role': 'user', 'content': message}]
  };
  
  var options = {
    'method': 'post',
    'headers': headers,
    'payload': JSON.stringify(payload),
    'muteHttpExceptions': true
  };
  
  try {
    var response = UrlFetchApp.fetch(url, options);
    var responseData = JSON.parse(response.getContentText());
    return responseData.content[0].text;
  } catch (error) {
    Logger.log('API call error: ' + error.toString());
    return "An error occurred: " + error.toString();
  }
}
