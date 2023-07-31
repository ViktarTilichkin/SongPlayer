const jsmediatags = window.jsmediatags;
const songs = [];
const inputFiles = document.querySelector('.input-file');
const list = document.querySelector('.list-song');
const send = document.querySelector('.send');
const filesEditor = document.querySelector('.files-editors');


inputFiles.addEventListener(
    'change',
    (event) => {
        filesEditor.innerHTML = '';
        //songs = [];
        const files = event.target.files;
        for (let i = 0; i < files.length; i++) {
            readTags(files[i]);
        }
    },
    false
);

function creatSongItem({ title, artist, cover }) {
    const img = document.createElement('img');
    img.style.backgroundImage = cover;
    img.style.width = '50px';
    img.style.height = '50px';
    img.style.backgroundSize = 'cover';

    const labelSongName = document.createElement('label');
    labelSongName.textContent = `${title}  -  ${artist}`;
    labelSongName.style.margin = '2%';

    const blockSongName = document.createElement('div');
    blockSongName.style.margin = '2%';
    blockSongName.style.textAlign = 'center';
    blockSongName.style.display = 'flex';

    blockSongName.appendChild(img);
    blockSongName.appendChild(labelSongName);

    filesEditor.appendChild(blockSongName);
}

function readTags(file) {
    jsmediatags.read(file, {
        onSuccess: function (tag) {
            const { title, artist, picture } = tag.tags;
            const { data, format } = picture;
            const base64String = data.reduce((result, item) => result + String.fromCharCode(item),'');
            const cover = `url(data:${format};base64,${window.btoa(base64String)})`;
            const song = { title, artist, cover }
            songs.push(song);
            creatSongItem(song);
        },
        onerror: function (error) {
            console.log(error);
        }
    })
}

send.addEventListener('click', () => {
    const formData = new FormData();
    const files = inputFiles.files;
    for (let i = 0; i < files.length; i++) {
        console.log(files[i]);
        formData.append('file', files[i]);
    }

    const response = fetch('https://localhost:7163/api/File', {
        method: 'POST',

        body: formData,
    });
    if (response.ok) {

    }
});

// const send = document.getElementById('send-files');

// send.addEventListener('click', () => {

//     const formData = new FormData();
//     const files = inputFile.files;
//     for (let i = 0; i < files.length; i++) {
//         formData.append('file', files[i]);
//     }
//     formData.append('data', fileNames);

//     const response = fetch('https://localhost:7060/WeatherForecast', {
//         method: 'POST',

//         body: formData,
//     });
//     if (response.ok) {

//     }
// });


// const inputFile = document.getElementById('custom-file');

// const filesEditor = document.querySelector('.files-editors');



