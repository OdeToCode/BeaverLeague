"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var axios_1 = require("axios");
var error_1 = require("./error");
var XSRF_TOKEN_KEY = "xsrfToken";
var XSRF_TOKEN_NAME_KEY = "xsrfTokenName";
function reportError(message, response) {
    var formattedMessage = message + " : Status " + response.status + " " + response.statusText;
    error_1.errorHandler.reportMessage(formattedMessage);
}
function setToken(_a) {
    var token = _a.token, tokenName = _a.tokenName;
    window.sessionStorage.setItem(XSRF_TOKEN_KEY, token);
    window.sessionStorage.setItem(XSRF_TOKEN_NAME_KEY, tokenName);
    axios_1.default.defaults.headers.common[tokenName] = token;
}
function initializeXsrfToken() {
    var token = window.sessionStorage.getItem(XSRF_TOKEN_KEY);
    var tokenName = window.sessionStorage.getItem(XSRF_TOKEN_NAME_KEY);
    if (!token || !tokenName) {
        axios_1.default.get("/api/xsrfToken")
            .then(function (r) { return setToken(r.data); })
            .catch(function (r) { return reportError("Could not fetch XSRFTOKEN", r); });
    }
    else {
        setToken({ token: token, tokenName: tokenName });
    }
}
var axiosExec = function (f, message) {
    return __awaiter(this, void 0, void 0, function () {
        var err_1;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, f()];
                case 1: return [2 /*return*/, _a.sent()];
                case 2:
                    err_1 = _a.sent();
                    reportError("Operation Failed: " + message, err_1.response);
                    throw err_1;
                case 3: return [2 /*return*/];
            }
        });
    });
};
var Api = /** @class */ (function () {
    function Api() {
    }
    Api.prototype.getAllGolfers = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                return [2 /*return*/, axiosExec(function () { return __awaiter(_this, void 0, void 0, function () {
                        var response;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/api/golfers")];
                                case 1:
                                    response = _a.sent();
                                    return [2 /*return*/, response.data];
                            }
                        });
                    }); }, "Fetch all golfers")];
            });
        });
    };
    Api.prototype.getActiveGolfers = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                return [2 /*return*/, axiosExec(function () { return __awaiter(_this, void 0, void 0, function () {
                        var response;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/api/golfers/active")];
                                case 1:
                                    response = _a.sent();
                                    return [2 /*return*/, response.data];
                            }
                        });
                    }); }, "Get active golfers")];
            });
        });
    };
    Api.prototype.setGolferActiveFlag = function (data, name) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                return [2 /*return*/, axiosExec(function () { return __awaiter(_this, void 0, void 0, function () {
                        var response;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.post("/api/golfers/" + data.id + "/activeflag", data)];
                                case 1:
                                    response = _a.sent();
                                    return [2 /*return*/, response.data];
                            }
                        });
                    }); }, "Setting update flag for " + name)];
            });
        });
    };
    Api.prototype.getMatchSet = function (id) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                return [2 /*return*/, axiosExec(function () { return __awaiter(_this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/api/matchset/" + id)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    }); }, "Fetch matchset " + id)];
            });
        });
    };
    return Api;
}());
initializeXsrfToken();
exports.api = new Api();
//# sourceMappingURL=api.js.map