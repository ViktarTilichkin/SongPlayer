const playBtn = document.querySelector('.play-stop'),
    likeBtn = document.querySelector('.like'),
    repeatBtn = document.querySelector('.repeat-btn'),
    title = document.getElementById('title'),
    singer = document.getElementById('singer'),
    image = document.querySelector('.img'),
    line = document.querySelector('.line'),
    lineTime = document.querySelector('.line-time'),
    time = document.querySelector('.time'),
    backBtn = document.querySelector(".back"),
    forwardBtn = document.querySelector(".forward"),
    audioTag = document.createElement('audio'),
    imgspotify = document.querySelector(".img-spotify"),
    closeBtn = document.querySelector(".closeBtn"),
    textPopUp = document.querySelector(".textPopUp");
let repeat = false;

const htmlObj = {
    playBtn,
    likeBtn,
    repeatBtn,
    title,
    singer,
    image,
    line,
    lineTime,
    time,
    backBtn,
    forwardBtn,
    audioTag
};

const playlist = [
    {
        name: 'Камнем по голове',
        singer: 'Король и Шут',
        path: '../audio/Korol_i_SHut_-_Kamnem_po_golove_(musmore.com).mp3',
        envelope: '../img/Киш.jpg',
        like: false
    },
    {
        name: 'Лесник',
        singer: 'Король и Шут',
        path: '../audio/Korol_i_SHut_-_Lesnik_(musmore.com).mp3',
        envelope: '../img/Киш2.jpg',
        like: false
    },
    {
        name: 'Прыгну со скалы',
        singer: 'Король и Шут',
        path: '../audio/Korol_i_SHut_-_Prygnu_so_skaly_(musmore.com).mp3',
        envelope: '../img/Киш3.jpg',
        like: false
    },
    {
        name: 'Я так соскучился',
        singer: 'Порнофильмы',
        path: '../audio/Pornofilmy_-_YA_tak_soskuchilsya_(musmore.com).mp3',
        envelope: '../img/Порнофильмы.jpg',
        like: false
    },
    {
        name: 'Утренний рассвет',
        singer: 'Король и шут',
        path: '../audio/trak5.mp3',
        envelope: '../img/Киш4.jpg',
        like: true
    }
];

function getAllMusic() {
    return playlist;
}

class Player {
    constructor(playlist, htmlObj) {
        this.songIndex = 0;
        this.checkPlay = false;
        this.playListSongs = playlist;
        this.htmlObj = htmlObj;
    }
    applyLikeSong(song) {
        const buttonType = song.like ? '../img/icon.svg' : '../img/like.png';
        this.htmlObj.likeBtn.style.backgroundImage = `url(${buttonType})`;
    }

    applySong(song) {
        this.htmlObj.title.textContent = song.name;
        this.htmlObj.singer.textContent = song.singer;
        this.htmlObj.image.style.backgroundImage = `url(${song.envelope})`;
        this.htmlObj.audioTag.src = song.path;
        this.applyLikeSong(song);
    }

    changeSong(currentSong) {
        this.applySong(currentSong);
        this.htmlObj.audioTag.play();
    }
    nextSong() {
        this.songIndex = this.songIndex == this.playListSongs.length - 1 ? 0 : this.songIndex + 1;
        return this.playListSongs[this.songIndex];
    }
    backSong() {
        this.songIndex = this.songIndex == 0 ? this.playListSongs.length - 1 : this.songIndex - 1;
        return this.playListSongs[this.songIndex];
    }
}

const player = new Player(getAllMusic(), htmlObj);

player.applySong(player.playListSongs[player.songIndex]);

likeBtn.addEventListener('click', function () {
    const song = player.playListSongs[player.songIndex];
    song.like = !song.like;
    player.applyLikeSong(song);
});

playBtn.addEventListener('click', function () {
    player.checkPlay = !player.checkPlay;
    const buttonType = player.checkPlay ? '../img/pause.svg' : '../img/playBtn.svg';
    playBtn.style.backgroundImage = `url(${buttonType})`;
    if (player.checkPlay) {
        htmlObj.audioTag.play();

    }
    else {
        htmlObj.audioTag.pause();
    }
});

forwardBtn.addEventListener('click', function () {
    player.changeSong(player.nextSong());
});

backBtn.addEventListener('click', function () {
    player.changeSong(player.backSong());
});

repeatBtn.addEventListener('click', function () {
    if (repeat) {
        repeat = false
        repeatBtn.style.animation = 'none';
    }
    else {
        repeat = true;
        repeatBtn.style.animation = '3s linear infinite rotate';
    }
})

audioTag.onended = function () {
    if (repeat) {
        audioTag.play();
    }
    else {
        player.changeSong(player.nextSong());
    }
}

function listSong() {
    textPopUp.innerHTML =
        `<ul>
            <li>${1} ${playlist[0].singer + ' ' + playlist[0].name}</li>
            <li>${2} ${playlist[1].singer + ' ' + playlist[1].name}</li>
            <li>${3} ${playlist[2].singer + ' ' + playlist[2].name}</li>
            <li>${4} ${playlist[3].singer + ' ' + playlist[3].name}</li>
            <li>${5} ${playlist[4].singer + ' ' + playlist[4].name}</li>
        </ul>`;
}

imgspotify.addEventListener('click', function () {
    listSong();
    PopUpShow();
    let index = 0;
    const list = document.querySelector("ul");
    list.addEventListener('click', (event) => {
        index = +event.target.textContent[0];
        player.applySong(player.playListSongs[index - 1]);
        player.nextSong();
        audioTag.play();
        const buttonType = !player.checkPlay ? '../img/pause.svg' : '../img/playBtn.svg';
        playBtn.style.backgroundImage = `url(${buttonType})`;
    });
});
closeBtn.addEventListener('click', function () {
    PopUpHide();
});



function updateProgress(event) {
    const {
        duration,
        currentTime
    } = event.srcElement;
    const progressPercent = (currentTime / duration) * 100;
    line.style.width = `${progressPercent}%`
    time.textContent = Math.round(currentTime, 1);
}
audioTag.addEventListener('timeupdate', updateProgress)

function setProgress(event) {
    const width = this.clientWidth;
    const click = event.offsetX;
    const duration = audioTag.duration;

    audioTag.currentTime = (click / width) * duration;
}

lineTime.addEventListener('click', setProgress);



$(document).ready(function () {
    PopUpHide();
});
function PopUpShow() {
    $("#popup1").show();
}
function PopUpHide() {
    $("#popup1").hide();
}