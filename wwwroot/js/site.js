// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//import JQuery from '/VisualStudioFiles/source/repos/--ASP.NET--/Project3/wwwroot/lib/jquery/jquery'
//$('reportBtn').click(() => {
//    alert("333");
//})

////document.getElementById('report_file_form').addEventListener('submit', function (e) {
////    //const modelJson = document.getElementById('reportJson').value;
////    e.preventDefault();
////    const form = document.getElementById('report_file_form');
////    const formData = new FormData(form)
////    let object = {}
////    formData.forEach((value, key) => object[key] = value)
////    let postReport = JSON.stringify(object)
////    //alert(document.querySelector('input[name="__RequestVerificationToken"]').value)
////    fetch('/reports', {
////        mode: "cors",
////        method: 'post',
////        headers: {
////            "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
////        },
////        body: object,
////    })
////        .then((response) => response.json())
////        .then((data) => alert("Result: ", JSON.stringify(data)))
////        .catch((error) => alert(error))
////})

let upvoteBtns = document.querySelectorAll(".upvoteCmt_btn");

for (let element of upvoteBtns) {
    let commentId = element.id
    element.addEventListener('click', function () {
        fetch(`comments/upvote?id=${commentId}`)
            .then((res) => res.json())
            .catch((error) => alert(error))
        let x = parseInt(document.getElementById(`upvoteCmt_count_${commentId}`).textContent, 10)
        x++;
        document.getElementById(`upvoteCmt_count_${commentId}`).textContent = x.toString();
    })
}

let downvoteBtns = document.querySelectorAll(".downvoteCmt_btn");

for (let element of downvoteBtns) {
    let commentId = element.id
    element.addEventListener('click', function () {
        fetch(`comments/downvote?id=${commentId}`)
            .then((res) => res.json())
            .catch((error) => alert(error))
        let x = parseInt(document.getElementById(`downvoteCmt_count_${commentId}`).textContent, 10)
        x++;
        document.getElementById(`downvoteCmt_count_${commentId}`).textContent = x.toString();
    })
}