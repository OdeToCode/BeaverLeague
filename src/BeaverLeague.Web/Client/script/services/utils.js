"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function find(array, predicate) {
    for (var i = 0; i < array.length; i++) {
        if (predicate(array[i], i)) {
            return array[i];
        }
    }
    return undefined;
}
exports.find = find;
function findById(array, id) {
    var _this = this;
    return find(array, function (thing) { return _this.id === id; });
}
exports.findById = findById;
//# sourceMappingURL=utils.js.map