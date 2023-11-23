function myFunction(){
    var inpName_resto = document.getElementById("Name_resto").value;
    var inpAdres_resto = document.getElementById("Adres_resto").value;
    var inpInfo_resto = document.getElementById("Info_resto").value;
    var inpUserRate_resto = document.getElementById("UserRate_resto").value;
    var inpCostRate_resto = document.getElementById("CostRate_resto").value;
    
    const url = 'http://localhost:5059/restoPost';
const options = {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
  },
  body: JSON.stringify({
    "restoransId": 0,
    "type": 1,
    "naming": inpName_resto,
    "adres": inpAdres_resto,
    "info": inpInfo_resto,
    "userRate": inpUserRate_resto,
    "costRate": inpCostRate_resto,
    "image": "string"
  })
};

fetch(url, options)
  .then(response => response.text())
  .then(result => console.log(result + "Успешно"))
  .catch(error => console.log('error', error + "не получилось, не фортануло"));

}