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


document.querySelector(".btn").addEventListener('click', async function () {
    const email = document.querySelector(".input-email").value;
    const pwd = document.querySelector(".input-password").value;
    const response = await fetch('https://localhost:7163/api/Account/Login', {
        method: 'POST',
        headers: {
            'Authorization': '1234',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            email,
            pwd,
        })
    });
    const arr = await response.json();
    console.log(arr);
});

window.location.href = 'file:///C:/Users/Flog/Documents/Hscool/SongPlayer_client/SongPlayer/Client/mainPage_auth/index.html';