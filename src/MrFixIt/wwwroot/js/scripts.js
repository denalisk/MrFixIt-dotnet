$(document).ready(function(){
  $("#claim-form").submit(function(event) {
    // This function claims a job for a worker using an ajax call
    event.preventDefault();
    var jobData = {};
    var dataArray = (($(this).serializeArray()));
    var urlAction = $(this).data('url-action');
    var errorbtn = $('.claimed-error');
    var successbtn = $('.claimed-tag');
    var claimbtn = $('.claim-button');
    for (let i = 0; i < dataArray.length; i++) {
        jobData[dataArray[i].name] = dataArray[i].value;
    }
    $.ajax({
      url: urlAction,
      type: 'POST',
      datatype: 'json',
      data: jobData,
      success: function(result) {
        claimbtn.addClass("hide");
        successbtn.removeClass("hide");
      },
      error: function(result) {
        claimbtn.addClass("hide");
        errorbtn.removeClass("hide");
      }
    })
  })
  $(".toggle-job-activity").click(function() {
    // This function marks a job as active/inactive
    var targetId = $(this).next().val();
    var activeString = '#active-text-' + targetId;
    $.ajax({
      url: '/Jobs/ToggleActive',
      type: 'POST',
      datatype: 'json',
      data: { targetId: targetId },
      success: function(result) {
        console.log(result);
        console.log(activeString.innerHTML);
        (result.pending === true) ? $(activeString).text('') : $(activeString).text('not ');
      },
      error: function(result) {
        console.log(result);
      }
    })
  })
})
