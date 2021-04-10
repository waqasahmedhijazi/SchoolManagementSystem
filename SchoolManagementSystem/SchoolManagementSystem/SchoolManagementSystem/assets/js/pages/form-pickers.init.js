!function (i) {
	"use strict"; function e() { } e.prototype.init = function () {
		
			 i(".datepicker").flatpickr({ enableTime: 0, dateFormat: "m-d-Y" })
			
	}, i.FormPickers = new e, i.FormPickers.Constructor = e
}(window.jQuery), function () { "use strict"; window.jQuery.FormPickers.init() }();