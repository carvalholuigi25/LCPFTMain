async function getData(apiname = "games") {
  var isSSL = true;
  var isLocal = true;
  var parthttp = isLocal ? "http" : (isSSL ? "https" : "http");
  var partport = isLocal ? "3000" : (isSSL ? "5001" : "5000");
  
  var myInit = { 
    method: 'GET',
    mode: 'cors',
    cache: 'default'
  };

  const resp = await fetch(`${parthttp}://localhost:${partport}/api/${apiname}`, myInit);

  if (!resp.ok) {
    const message = `An error has occured: ${resp.status}`;
    console.log(message);
    // throw new Error(message);
  }

  const datax = await resp.json();
  return datax;
}

// function writeTblGames(games) {
//   var cnt = "";
//   cnt = `
//   <div class="table-responsive">
//       <table class="table table-bordered">
//           <thead>
//               <tr>
//                   <th>Id</th>
//                   <th>Title</th>
//               </tr>
//           </thead>
//           <tbody>`;
//               for(var i = 0; i < games.length; i++) {
//                   cnt += `
//                   <tr>
//                       <td>${games[i].id}</td>
//                       <td>${games[i].title}</td>
//                   </tr>`;
//               }
//               cnt += `
//           </tbody>
//       </table>
//   </div>`;
//   return cnt;
// }

// function writeTblMovies(movies) {
//   var cnt = "";
//   cnt = `
//   <div class="table-responsive">
//       <table class="table table-bordered">
//           <thead>
//               <tr>
//                   <th>Id</th>
//                   <th>Title</th>
//               </tr>
//           </thead>
//           <tbody>`;
//               for(var i = 0; i < movies.length; i++) {
//                   cnt += `
//                   <tr>
//                       <td>${movies[i].id}</td>
//                       <td>${movies[i].title}</td>
//                   </tr>`;
//               }
//               cnt += `
//           </tbody>
//       </table>
//   </div>`;
//   return cnt;
// }

// function writeTblTVSeries(tvseries) {
//   var cnt = "";
//   cnt = `
//   <div class="table-responsive">
//       <table class="table table-bordered">
//           <thead>
//               <tr>
//                   <th>Id</th>
//                   <th>Title</th>
//               </tr>
//           </thead>
//           <tbody>`;
//               for(var i = 0; i < tvseries.length; i++) {
//                   cnt += `
//                   <tr>
//                       <td>${tvseries[i].id}</td>
//                       <td>${tvseries[i].title}</td>
//                   </tr>`;
//               }
//               cnt += `
//           </tbody>
//       </table>
//   </div>`;
//   return cnt;
// }

// function writeTblUsers(users) {
//   var cnt = "";
//   cnt = `
//   <div class="table-responsive">
//       <table class="table table-bordered">
//           <thead>
//               <tr>
//                   <th>Id</th>
//                   <th>Username</th>
//               </tr>
//           </thead>
//           <tbody>`;
//               for(var i = 0; i < users.length; i++) {
//                   cnt += `
//                   <tr>
//                       <td>${users[i].id}</td>
//                       <td>${users[i].username}</td>
//                   </tr>`;
//               }
//               cnt += `
//           </tbody>
//       </table>
//   </div>`;
//   return cnt;
// }

export { getData };