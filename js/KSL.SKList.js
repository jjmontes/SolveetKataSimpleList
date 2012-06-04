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
SKList.prototype.values = function() {
	var arrayValues = new Array();
	for (var index = 0; index < this._list.length; index++) {
		arrayValues.push(this._list[index].value);
	}

	return arrayValues;
}
SKList.prototype.delete = function(node) {
	var idx = -1;
	for (var index = 0; index < this._list.length; index++) {
		var item = this._list[index];
		if (item.value == node.value) {
			idx = index;
			break;
		}
	}
	if (idx != -1) {
		this._list.splice(idx, 1);
	}
}