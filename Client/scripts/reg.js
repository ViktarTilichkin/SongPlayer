document.querySelector(".btn").addEventListener('click', async function () {
    const name = document.querySelector(".input-name").value;
    const email = document.querySelector(".input-email").value;
    const password = document.querySelector(".input-password").value;
    const ConfPassword = document.querySelector(".confirm-password").value;
    if (password === ConfPassword) {
        const response = await fetch('https://localhost:7163/api/User/create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name,
                email,
                password,
            })
        });
        const arr = await response.json();
    }
    else {
        alert("error");
    }
})
