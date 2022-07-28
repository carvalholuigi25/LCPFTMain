import { getData } from './mscripts.js';

document.addEventListener("DOMContentLoaded", function() {
    var gamesblk = document.querySelectorAll('#gamesblk')[0];
    var moviesblk = document.querySelectorAll('#moviesblk')[0];
    var tvseriesblk = document.querySelectorAll('#tvseriesblk')[0];
    var usersblk = document.querySelectorAll('#usersblk')[0];

    if(gamesblk) {
         getData("games").then(games => {
            gamesblk.innerHTML = "<pre style='white-space: pre-wrap'>"+JSON.stringify(games, null, 4)+"</pre>";
        }).catch(err => console.log(err));
    }

    if(moviesblk) {
         getData("movies").then(movies => {
            moviesblk.innerHTML = "<pre style='white-space: pre-wrap'>"+JSON.stringify(movies, null, 4)+"</pre>";
        }).catch(err => console.log(err));
    }

    if(tvseriesblk) {
         getData("tvseries").then(tvseries => {
            tvseriesblk.innerHTML = "<pre style='white-space: pre-wrap'>"+JSON.stringify(tvseries, null, 4)+"</pre>";
        }).catch(err => console.log(err));
    }

    if(usersblk) {
         getData("users").then(users => {
            usersblk.innerHTML = "<pre style='white-space: pre-wrap'>"+JSON.stringify(users, null, 4)+"</pre>";
        }).catch(err => console.log(err));
    }
});