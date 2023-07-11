// document.querySelector("button").addEventListener('click', function () {
//     let xhr = new XMLHttpRequest();

//     xhr.open('Get', 'https://localhost:7163/WeatherForecast');
//     xhr.send();
//     xhr.onload = () => {
//         const arr = JSON.parse(xhr.response);
//         const weather = document.querySelector(".weather");
//         for (i = 0; i < arr.length; i++) {
//             let span = document.createElement('span');
//             span.textContent = JSON.stringify(arr[i]);
//             weather.appendChild(span);
//         }
//     };
// })

// document.querySelector("button").addEventListener('click', async function () {
//     const response = await fetch('https://localhost:7037/WeatherForecast', {
//         method: 'Get',
//         headers: {'Authorization':'1234'}
//     });
//     const arr = await response.json();
//     const weather = document.querySelector(".weather");
//     for (i = 0; i < arr.length; i++) {
//         let span = document.createElement('span');
//         span.textContent = JSON.stringify(arr[i]) + 'SADASDASD';
//         weather.appendChild(span);
//     }
// })

document.querySelector(".login").addEventListener('click', async function () {
    const Email = document.querySelector(".email").value;
    const Password = document.querySelector(".pwd").value;
    const response = await fetch('https://localhost:7037/WeatherForecast', {
        method: 'POST',
        headers: {
            'Authorization': '1234',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            Email,
            Password,
        })
    });
    const arr = await response.json();
})