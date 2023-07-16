const inputFile = document.getElementById('custom-file');
const audioTag = document.createElement('audio');

inputFile.addEventListener(
    'change',
    async (event) => {
        const files = event.target.files;

        const formData = new FormData();
        for (let i = 0; i < files.length; i++) {
            formData.append('file', files[i]);
        }

        const response = await fetch('https://localhost:7060/WeatherForecast', {
            method: 'POST',

            body: formData,
        });
        if (response.ok) {
            const result = await response.json();
            audioTag.src = `data:audio/mp3;base64,${result}`;
            audioTag.play();
        }
    },
    false
);

