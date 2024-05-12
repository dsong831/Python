function doGet(e) {
  var template = HtmlService.createTemplateFromFile('index');
  return template.evaluate();
}

function include(filename) {
  return HtmlService.createHtmlOutputFromFile(filename).getContent();
}

function updateGoogleSheet(inputText) {
  var ss = SpreadsheetApp.openById('1zAh-qD2YvLnB9swaXI1SXlasKWlchlp8TFB_yLhGmq0');
  var sheet = ss.getSheetByName('Sheet1');
  sheet.getRange('A1').setValue(inputText);
}

function sendInquiryEmail(inquiryContent, contact, email) {
  var recipient = "dsong831@gmail.com";
  var subject = "기타 문의사항";
  var body = "문의 내용:\n" + inquiryContent + "\n\n연락처: " + contact + "\n이메일: " + email;
  GmailApp.sendEmail(recipient, subject, body);
}

function processTuningForm(date, concert, company, contact, paymentMethod, taxInvoice, issueDate, issueEmail) {
  try {
    var recipient = "dsong831@gmail.com";
    var subject = "예술의전당 인춘아트홀 조율 신청";
    var body = "날짜: " + date + "\n" +
               "공연 명: " + concert + "\n" +
               "기획사 이름: " + company + "\n" +
               "연락처: " + contact + "\n" +
               "조율비 지급 방식: " + paymentMethod + "\n" +
               "세금계산서 발행: " + (taxInvoice ? "예" : "아니오") + "\n";

    if (taxInvoice) {
      body += "발급 받을 날짜: " + issueDate + "\n" +
              "발급 받을 Email: " + issueEmail + "\n";
    }

    GmailApp.sendEmail(recipient, subject, body);
    return "조율 신청이 성공적으로 전송되었습니다.";
  } catch (error) {
    console.error("전송 중 오류 발생:", error);
    throw new Error("전송 중 오류가 발생했습니다. 다시 시도해 주세요.");
  }
}
