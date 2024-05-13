function doGet(e) {
  var template = HtmlService.createTemplateFromFile('index');
  return template.evaluate();
}

function include(filename) {
  return HtmlService.createHtmlOutputFromFile(filename).getContent();
}

function sendInquiryEmail(inquiryContent, contact, email) {
  var recipient = "dsong831@gmail.com";
  var subject = "기타 문의사항";
  var body = "문의 내용:\n" + inquiryContent + "\n\n연락처: " + contact + "\n이메일: " + email;
  GmailApp.sendEmail(recipient, subject, body);
}

function updateTuningSheet(date, concert, pianoNumber, company, contact, paymentMethod, taxInvoice, issueDate, issueEmail) {
  var ss = SpreadsheetApp.openById('1zAh-qD2YvLnB9swaXI1SXlasKWlchlp8TFB_yLhGmq0');
  var sheet = ss.getSheetByName('Tuning_Requests');

  var data = sheet.getDataRange().getValues();
  var newRow = [date, concert, pianoNumber, company, contact, paymentMethod, taxInvoice ? '예' : '아니오', issueDate, issueEmail, '미완료'];

  data.push(newRow);
  sheet.getRange(1, 1, data.length, data[0].length).setValues(data);
}

function getCompanyHistory(company) {
  var ss = SpreadsheetApp.openById('1zAh-qD2YvLnB9swaXI1SXlasKWlchlp8TFB_yLhGmq0');
  var sheet = ss.getSheetByName('Tuning_Requests');

  var data = sheet.getDataRange().getValues();
  var history = data.filter(function(row) {
    return row[3].toLowerCase() === company.toLowerCase();
  });

  if (history.length === 0) {
    return "해당 기획사의 이력이 없습니다.";
  }

  var result = history.map(function(row) {
    var status = row[9] === '완료' ? '결제 완료' : '미 결제';
    return [row[0], row[1], row[2], status].join(' | ');
  });

  return result.join('\n');
}

function getCompanyHistoryData() {
  try {
    var ss = SpreadsheetApp.openById('1zAh-qD2YvLnB9swaXI1SXlasKWlchlp8TFB_yLhGmq0');
    var sheet = ss.getSheetByName('Tuning_Requests');
    var data = sheet.getDataRange().getValues();
    console.log('시트 데이터:', data);

    if (data.length === 0) {
      console.error('시트에 데이터가 없습니다.');
      return [];
    }

    var headers = data[0];
    var dateIndex = headers.indexOf('날짜');
    var concertIndex = headers.indexOf('공연 명');
    var pianoIndex = headers.indexOf('피아노 번호');
    var companyIndex = headers.indexOf('기획사 이름');
    var statusIndex = headers.indexOf('결제 상태');
    console.log('열 인덱스:', dateIndex, concertIndex, pianoIndex, companyIndex, statusIndex);

    if (dateIndex === -1 || concertIndex === -1 || pianoIndex === -1 || companyIndex === -1 || statusIndex === -1) {
      console.error('필요한 열 이름을 찾을 수 없습니다.');
      return [];
    }

    var companyData = data.slice(1).map(function(row) {
      return [
        row[dateIndex],
        row[concertIndex],
        row[pianoIndex],
        row[companyIndex],
        row[statusIndex]
      ];
    });
    console.log('추출된 데이터:', companyData);

    return companyData;
  } catch (error) {
    console.error('데이터를 불러오는 중 오류가 발생했습니다:', error);
    return [];
  }
}

function updateCompanyHistoryData(rowIndex, columnIndex, newValue) {
  var ss = SpreadsheetApp.openById('1zAh-qD2YvLnB9swaXI1SXlasKWlchlp8TFB_yLhGmq0');
  var sheet = ss.getSheetByName('Tuning_Requests');
  var data = sheet.getDataRange().getValues();
  var headers = data.shift();
  var companyIndex = headers.indexOf('기획사 이름');
  var row = data.find(function(row) {
    return row[companyIndex] === rowIndex;
  });
  if (row) {
    sheet.getRange(data.indexOf(row) + 2, columnIndex + 1).setValue(newValue);
  }
}

function processTuningForm(date, concert, pianoNumber, company, contact, paymentMethod, taxInvoice, issueDate, issueEmail) {
  try {
    var recipient = "dsong831@gmail.com";
    var subject = "예술의전당 인춘아트홀 조율 신청";
    var body = "날짜: " + date + "\n" +
               "공연 명: " + concert + "\n" +
               "피아노 번호: " + pianoNumber + "\n" +
               "기획사 이름: " + company + "\n" +
               "연락처: " + contact + "\n" +
               "조율비 지급 방식: " + paymentMethod + "\n" +
               "세금계산서 발행: " + (taxInvoice ? "예" : "아니오") + "\n";

    if (taxInvoice) {
      body += "발급 받을 날짜: " + issueDate + "\n" +
              "발급 받을 Email: " + issueEmail + "\n";
    }

    GmailApp.sendEmail(recipient, subject, body);
    updateTuningSheet(date, concert, pianoNumber, company, contact, paymentMethod, taxInvoice, issueDate, issueEmail);
    return "조율 신청이 성공적으로 전송되었습니다.";
  } catch (error) {
    console.error("전송 중 오류 발생:", error);
    throw new Error("전송 중 오류가 발생했습니다. 다시 시도해 주세요.");
  }
}
