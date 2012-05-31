$(document).ready(function(){
	module("Kata Simple List: BasicListTest");
	test( 'At new List, find "fred" return null.', function() {
		var list = new SKList();
		
		equal (list.find("fred"), null);
	} );
});

