$(document).ready(function(){
  $("#claim-job").click(function() {
    var jobData = {};
    var dataArray = (($(this).serializeArray()));
    console.log(dataArray);
    for (let i = 0; i < dataArray.length; i++) {
        jobData[dataArray[i].name] = dataArray[i].value;
    }
    console.log(jobData);
  })
})
