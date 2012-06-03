$(document).ready(function(){
	module("Kata Simple List: BasicListTest");
	test( 'At new List, find "fred" return null.', function() {
		var list = new SKList();
		
		equal (list.find("fred"), null);
	} );
	test( 'At a List with node "fred", find "fred" return the node "fred".', function() {
        var list = new SKList();
 
        list.add("fred");
        equal (list.find("fred").value, "fred");
    } );
});

