$(document).ready(function(){
  $("#claim-form").submit(function(event) {
    event.preventDefault();
    var jobData = {};
    var dataArray = (($(this).serializeArray()));
    var urlAction = $(this).data('url-action');
    for (let i = 0; i < dataArray.length; i++) {
        jobData[dataArray[i].name] = dataArray[i].value;
    }
    $.ajax({
      url: urlAction,
      type: 'POST',
      datatype: 'json',
      data: jobData,
      success: function(result) {
        console.log("success");
        console.log(urlAction);
      },
      error: function(result) {
        console.log("error");
      }
    })
  })
})
