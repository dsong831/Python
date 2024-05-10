function checkHistory() {
  const name = document.getElementById('name').value;
  const pianoNumber = document.getElementById('piano_number').value;
  const historyResult = document.getElementById('history-result');

  if (name && pianoNumber) {
    fetch('/check-history', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded',
      },
      body: `name=${encodeURIComponent(name)}&piano_number=${encodeURIComponent(pianoNumber)}`,
    })
      .then(response => response.json())
      .then(historyData => {
        if (historyData.length > 0) {
          let historyHtml = '<h4>기존 이력</h4>';
          historyHtml += '<ul>';
          for (const history of historyData) {
            historyHtml += `<li>${history.date}: ${history.comment}</li>`;
          }
          historyHtml += '</ul>';
          historyResult.innerHTML = historyHtml;
        } else {
          historyResult.innerHTML = '<p>환영합니다! 첫 방문을 축하드립니다.</p>';
        }
      })
      .catch(error => {
        console.error('Error:', error);
        historyResult.innerHTML = '<p>오류가 발생했습니다. 다시 시도해주세요.</p>';
      });
  } else {
    historyResult.innerHTML = '<p>이름과 피아노 번호를 입력해주세요.</p>';
  }
}

function resetHistory() {
  const name = document.getElementById('name').value;
  const pianoNumber = document.getElementById('piano_number').value;
  const historyResult = document.getElementById('history-result');

  if (name && pianoNumber) {
    fetch('/reset-history', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded',
      },
      body: `name=${encodeURIComponent(name)}&piano_number=${encodeURIComponent(pianoNumber)}`,
    })
      .then(response => response.json())
      .then(data => {
        historyResult.innerHTML = `<p>${data.message}</p>`;
      })
      .catch(error => {
        console.error('Error:', error);
        historyResult.innerHTML = '<p>오류가 발생했습니다. 다시 시도해주세요.</p>';
      });
  } else {
    historyResult.innerHTML = '<p>이름과 피아노 번호를 입력해주세요.</p>';
  }
}