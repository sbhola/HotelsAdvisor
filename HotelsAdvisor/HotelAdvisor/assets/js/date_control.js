$(function(){
			window.prettyPrint && prettyPrint();
			//$('#dp1').datepicker({
				//format: 'mm-dd-yyyy'
			//});
			$('#DOB').data({date: '01-01-1970'});
			$("#DOB").datepicker({
				format: "dd-mm-yyyy",
				viewMode: "years", 
				minViewMode: "dates",
				//setStartDate: '+1d'
				//autoclose: true,
				
			});
			$('#dp2').datepicker();
			$('#dp3').datepicker();
			//$('#dp4').datepicker();
			$('#dp6').datepicker();
			$('#dp7').datepicker();
			$('#dp8').datepicker();
			$('#dp9').datepicker();
			$('#dp11').datepicker();
			$('#dp12').datepicker();
			$('.dtpicker').datepicker();			
			$('#dpYears').datepicker();
			$('#dpMonths').datepicker();
			
			
			var startDate = new Date(1950,1,1);
			var endDate = new Date(2012,1,25);
			$('#dp4').datepicker()
				.on('changeDate', function(ev){
					if (ev.date.valueOf() > endDate.valueOf()){
						$('#alert').show().find('strong').text('The start date can not be greater then the end date');
					} else {
						$('#alert').hide();
						startDate = new Date(ev.date);
						$('#startDate').text($('#dp4').data('date'));
					}
					$('#dp4').datepicker('hide');
				});
			$('#dp5').datepicker()
				.on('changeDate', function(ev){
					if (ev.date.valueOf() < startDate.valueOf()){
						$('#alert').show().find('strong').text('The end date can not be less then the start date');
					} else {
						$('#alert').hide();
						endDate = new Date(ev.date);
						$('#endDate').text($('#dp5').data('date'));
					}
					$('#dp5').datepicker('hide');
				});
				
			$('#dp6').datepicker()
				.on('changeDate', function(ev){
					if (ev.date.valueOf() > endDate.valueOf()){
						$('#alert').show().find('strong').text('The start date can not be greater then the end date');
					} else {
						$('#alert').hide();
						startDate = new Date(ev.date);
						$('#startDate').text($('#dp6').data('date'));
					}
					$('#dp6').datepicker('hide');
				});
				
			$('#dp7').datepicker()
				.on('changeDate', function(ev){
					if (ev.date.valueOf() > endDate.valueOf()){
						$('#alert').show().find('strong').text('The start date can not be greater then the end date');
					} else {
						$('#alert').hide();
						startDate = new Date(ev.date);
						$('#startDate').text($('#dp7').data('date'));
					}
					$('#dp7').datepicker('hide');
				});
				
		  <!-- Calender Control Script Dparture and Returning Time Start-->
				
				$(".form_datetime").datetimepicker({
					
					 format: "dd MM yyyy - hh:ii"
				 });
				<!-- Calender Control Script Dparture and Returning Time End-->
				
		});