document.addEventListener('DOMContentLoaded', function() {
    myFunction();
  });

function myFunction() 
{
    const url = 'http://localhost:5059/RestoGet';
    const headers = {
    'accept': 'text/plain'
    };

    fetch(url, { headers })
    .then(response => response.text())
    .then(data => {
        const resultElement = document.getElementById('result');
        resultElement.textContent = data;
    })
    .catch(error => console.log(error));
    console.log('Страница загружена');
}