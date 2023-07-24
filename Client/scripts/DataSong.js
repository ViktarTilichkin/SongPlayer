const inputFiles = document.querySelector('.input-file');
const list = document.querySelector('.list-song');
const send = document.querySelector('.send');
const jsmediatags = window.jsmediatags;


inputFiles.addEventListener('change', (event) => {
    const files = event.target.files;
    for (i = 0; i < files.length; i++) {
        readTags(files[i]);
    }
})


function readTags(file) {
    jsmediatags.read(file), {
        onSuccess: function (tag) {
            filesEditor.innerHTML = '';
            const data = tag.tags.picture.data;
            const format = tag.tags.picture.format;
            let base64String = "";
            for (let i = 0; i < data.length; i++) {
                base64String += String.fromCharCode(data[i])
            }
            const cover = document.createElement('div').style.backgroundImage = `url(data:${format};base64,${window.btoa(base)})`;
            const title = document.createElement('div').textContent = tag.tags.title;
            const artist = document.createElement('div').textContent = tag.tags.artist;
            const album = document.createElement('div').textContent = tag.tags.album;
            filesEditor.appendChild(cover, title, artist, album);
        },
        onError: function (error) {
            console.log(error);
        }
    }
}


// inputFiles.addEventListener(
//     'change',
//     (event) => {
//         const reader = new FileReader()
//         reader.onload = function () {
//             const buffer = this.result

//             // MP3Tag Usage
//             const mp3tag = new MP3Tag(buffer)
//             mp3tag.read()

//             // Handle error if there's any
//             if (mp3tag.error !== '') throw new Error(mp3tag.error)
//             else console.log(mp3tag.tags)
//         }

//         if (this.files.length > 0) {
//             reader.readAsArrayBuffer(this.files[0])
//         }




//         for (let i = 0; i < files.length; i++) {
//             const file = files[i];
//             list.innerHTML += `<div>${file}</div>`;
//             console.log(file);
//         }
//     }, false
// );


send.addEventListener('click', () => {

    const formData = new FormData();
    const files = inputFiles.files;
    for (let i = 0; i < files.length; i++) {
        formData.append('file', files[i]);
    }
    formData.append('data', fileNames);

    const response = fetch('https://localhost:7060/WeatherForecast', {
        method: 'POST',

        body: formData,
    });
    if (response.ok) {

    }
});



// document.querySelector('input[type="file"]').onchange = function (e) {
//     var reader = new FileReader();

//     reader.onload = function (e) {
//         var dv = new jDataView(this.result);

//         // "TAG" starts at byte -128 from EOF.
//         // See http://en.wikipedia.org/wiki/ID3
//         if (dv.getString(3, dv.byteLength - 128) == 'TAG') {
//             var title = dv.getString(30, dv.tell());
//             var artist = dv.getString(30, dv.tell());
//             var album = dv.getString(30, dv.tell());
//             var year = dv.getString(4, dv.tell());
//         } else {
//             // no ID3v1 data found.
//         }
//     };

//     reader.readAsArrayBuffer(this.files[0]);
// };

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

// let fileNames = []
// inputFile.addEventListener(
//     'change',
//     (event) => {
//         filesEditor.innerHTML = '';

//         const files = event.target.files;
//         for (let i = 0; i < files.length; i++) {
//             const file = files[i];
//             const blockSongName = document.createElement('div');
//             const labelSongName = document.createElement('label');
//             labelSongName.textContent = 'Name';
//             fileNames.push(file.name)
//             const inputSongName = document.createElement('input');
//             inputSongName.value = file.name;
//             inputSongName.addEventListener('change', (event) => {
//                 fileNames[i] = event.target.value;
//             });


//             blockSongName.appendChild(labelSongName);
//             blockSongName.appendChild(inputSongName);

//             filesEditor.appendChild(blockSongName);
//         }
//     },
//     false
// );

