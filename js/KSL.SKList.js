function SKList() {
    this._list = new Array();

	return this;
}
SKList.prototype.find = function(value) {
	    for (var index = 0; index < this._list.length; index++) {
        var item = this._list[index];
        if (item.value == value) {
            return item;
        }
    }
 
    return null;
}
SKList.prototype.add = function(value) {
    var node = new SKNode();
    node.value = value;
    this._list.push(node);
}
