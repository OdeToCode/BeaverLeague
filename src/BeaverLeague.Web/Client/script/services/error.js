"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ErrorHandler = /** @class */ (function () {
    function ErrorHandler() {
    }
    ErrorHandler.prototype.reportError = function (error) {
        alert(error.message);
    };
    ErrorHandler.prototype.reportMessage = function (message) {
        alert(message);
    };
    return ErrorHandler;
}());
exports.errorHandler = new ErrorHandler();
//# sourceMappingURL=error.js.map