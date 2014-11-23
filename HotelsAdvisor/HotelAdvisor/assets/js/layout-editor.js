$(function(){

	$('.carousel').carousel();
	
	
	$('body').delegate('.layout-editor-hiddenmenus li','click',function(){
		$(this).children('div.editor-hiddenmenus').fadeIn();
	})
	$('.layout-editor-hiddenmenus li').mouseleave(function(){
		$(this).find('div.editor-hiddenmenus').fadeOut('fast');
	
	});
	

		// -------------------- Tooltip on hover 
	$('.layout-editor-overlay .settings li').tooltip({
		"trigger":"hover",
		"placement":"bottom"
	});

	// ---------------------- Display Page setting popups
	$('a.template-modal-show').click(function(){

		$(this).parent('.modal-parent').siblings().each(function(){
			$(this).find('div.template-modal').fadeOut();
			$('.template-modal-show').removeClass('open');
		});
		
		if($(this).hasClass('open')){
			$(this).removeClass('open');
		}else{
			$(this).addClass('open');
			$(this).next('div.template-modal').fadeIn();
		}
		
	});
	
	$('.template-modal .close-edit').click(function(){
		$(this).parents('.template-modal').fadeOut();
		$('.template-modal-show').removeClass('open');
	});

	$('.dropdown a').click(function(){
		$('.template-modal-show').next('div.template-modal').fadeOut();
		$('.template-modal-show').each(function() {
			$(this).removeClass('open');
		});
	});


	// ---------------------- Text editor plugin
	var editor = new MediumEditor('.editable', {
		anchorInputPlaceholder: 'Type a link',
		buttons: ['header1', 'header2','anchor', 'italic'],
		diffLeft: 25,
		diffTop: 10,
		firstHeader: 'h1',
		secondHeader: 'h2',
		delay: 1000,
		targetBlank: true,
	});

	$('.dropdown-toggle').dropdown();


	// ---------------------- Open edit panel
	$('body').delegate('.layout-editor-overlay a','click',function(){
		$(this).parents('.layout-editor-widget').addClass('layout-editor-open');
		$(this).parents('.layout-editor-widget').children('.edit-panel').slideDown();
//		$(this).parents('.layout-editor-widget').find(".content").selectText().focus();
		$(this).parents('.layout-editor-widget').find(".content").focus();
	});
	


	// ---------------------- apply border to selected option
	$('body').delegate('.layout-editor-widget .edit-panel ul li','click',function(){
		$(this).addClass('active').siblings().removeClass('active');
	});


	// ---------------------- Image shape options
	
	$(document).delegate('.layout-editor-imgbox .edit-panel ul li','click',function(){
		var shape = $(this).data('shape');
		$(this).parents('.layout-editor-widget').append('<div class="layout-editor-preloader"><div class="loader"></div></div>');
		
		$(this).parents('.layout-editor-imgbox').removeClass (function (index, css) {
			return (css.match (/(^|\s)shape-\S+/g) || []).join(' ');
		});
		$(this).parents('.layout-editor-imgbox').addClass(shape);
		
		$(this).parents('.layout-editor-widget').find('.layout-editor-preloader').delay(1000).fadeOut(function(){
			$(this).remove();
		});
		
	});


	// ---------------------- Deal BG color options
	$('body').delegate('.layout-editor-offer .edit-panel ul.bg-color li','click',function(){
		var color = $(this).data('color');
		$(this).parents('.layout-editor-offer').children('span').removeClass (function (index, css) {
			return (css.match (/(^|\s)bg-\S+/g) || []).join(' ');
		});
		$(this).parents('.layout-editor-offer').children('span').addClass(color,1500,"easeOutCirc");
	});


	// ---------------------- Deal Font options
	$('body').delegate('.layout-editor-offer .edit-panel ul.bg-font li','click',function(){
		$(this).parents('.layout-editor-offer').children('span').removeClass (function (index, css) {
			return (css.match (/(^|\s)font-\S+/g) || []).join(' ');
		});
		$(this).parents('.layout-editor-offer').children('span').addClass($(this).data('font'));
	});


	// ---------------------- Remove open class ans close edit panel 
	$('body').delegate('.layout-editor-widget .edit-panel .button-panel .close-edit','click',function(){
		$(this).parents('.layout-editor-widget').children('.edit-panel').slideUp(function(){
			$(this).parents('.layout-editor-widget').removeClass("layout-editor-open");
		});
	});


	// ---------------------- Function for select text for edit
	jQuery.fn.selectText = function(){
		var doc = document;
		var element = this[0];
		console.log(this, element);
		if (doc.body.createTextRange) {
			var range = document.body.createTextRange();
			range.moveToElementText(element);
			range.select();
		} else if (window.getSelection) {
			var selection = window.getSelection(); 
			var range = document.createRange();
			range.selectNodeContents(element);
			selection.removeAllRanges();
			selection.addRange(range);
		}
	};


	// ------------------ Close all dialogs on click of body
	$(document).mouseup(function(e) {
		if ($(e.target).parents("a.template-modal-show, div.template-modal").length === 0) {
			$('div.template-modal').fadeOut();
			$('a.template-modal-show').removeClass('open');
		}
	});
	

});
