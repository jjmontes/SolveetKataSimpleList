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
	test( 'At a List with nodes "fred" and "wilma", values function returns an array with values "fred" and "wilma"', function() {
        var list = new SKList();
 
        list.add("fred");
        list.add("wilma");
        equal (list.find("wilma").value, "wilma");
		
		deepEqual (list.values(), ["fred", "wilma"]);
    } );
	test( 'At a List with nodes "fred", "wilma", "betty" and "barney" values function returns an array with its values.', function() {
        var list = new SKList();
 
        list.add("fred");
        list.add("wilma");
        list.add("betty");
        list.add("barney");
		
		deepEqual (list.values(), ["fred", "wilma", "betty", "barney"]);
	} );
	test( 'At a List with nodes "fred", "wilma", "betty" and "barney" delete function remove specified node.', function() {
        var list = new SKList();
 
        list.add("fred");
        list.add("wilma");
        list.add("betty");
        list.add("barney");
		
		list.delete(list.find("wilma"));
		deepEqual (list.values(), ["fred", "betty", "barney"]);
		
		list.delete(list.find("barney"));
		deepEqual (list.values(), ["fred", "betty"]);
		
		list.delete(list.find("fred"));
		deepEqual (list.values(), ["betty"]);
		
		list.delete(list.find("betty"));
		deepEqual (list.values(), []);
	});
});
