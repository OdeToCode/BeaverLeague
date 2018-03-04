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
var services_1 = require("services");
var EditMatchSetStore = /** @class */ (function () {
    function EditMatchSetStore(component) {
        this.component = component;
        this.golfers = [];
        this.inactives = [];
        this.selected = [];
        this.matchset = {
            id: null,
            seasonId: null,
            matchSetNumber: null,
            inactives: [],
            matches: []
        };
    }
    EditMatchSetStore.prototype.load = function (id) {
        return __awaiter(this, void 0, void 0, function () {
            var golfers, matchset;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, services_1.api.getActiveGolfers()];
                    case 1:
                        golfers = _a.sent();
                        return [4 /*yield*/, services_1.api.getMatchSet(id)];
                    case 2:
                        matchset = _a.sent();
                        this.arrangeData(golfers, matchset);
                        return [2 /*return*/];
                }
            });
        });
    };
    EditMatchSetStore.prototype.produceState = function () {
        return {
            golfers: this.golfers,
            matchset: this.matchset,
            inactives: this.inactives
        };
    };
    EditMatchSetStore.prototype.arrangeData = function (golfers, matchset) {
        var availableGolfers = [];
        var inactives = [];
        var _loop_1 = function (golfer) {
            var playing = matchset.matches.filter(function (m) {
                return (m.golferA && m.golferA.id == golfer.id) ||
                    (m.golferB && m.golferB.id == golfer.id);
            });
            var inactive = matchset.inactives.filter(function (i) { return i.golferId == golfer.id; });
            if (playing.length === 0 && inactive.length === 0) {
                availableGolfers.push(golfer);
            }
        };
        for (var _i = 0, golfers_1 = golfers; _i < golfers_1.length; _i++) {
            var golfer = golfers_1[_i];
            _loop_1(golfer);
        }
        var _loop_2 = function (inactive) {
            var find = golfers.filter(function (g) { return g.id == inactive.golferId; });
            if (find.length > 0) {
                inactives.push({
                    id: find[0].id,
                    firstName: find[0].firstName,
                    lastName: find[0].lastName
                });
            }
        };
        for (var _a = 0, _b = matchset.inactives; _a < _b.length; _a++) {
            var inactive = _b[_a];
            _loop_2(inactive);
        }
        this.golfers = availableGolfers;
        this.matchset = matchset;
        this.inactives = inactives;
        this.component.setState(this.produceState());
    };
    EditMatchSetStore.prototype.pairGolfers = function () {
        this.golfers.splice(this.golfers.indexOf(this.selected[0]), 1);
        this.golfers.splice(this.golfers.indexOf(this.selected[1]), 1);
        this.matchset.matches.push({
            id: -(this.matchset.matches.length + 1), golferA: this.selected[0], golferB: this.selected[1]
        });
    };
    EditMatchSetStore.prototype.deleteMatch = function (id) {
    };
    EditMatchSetStore.prototype.selectGolfer = function (golfer) {
        golfer.isSelected = !golfer.isSelected;
        if (golfer.isSelected) {
            this.selected.push(golfer);
        }
        else {
            this.selected.splice(this.selected.indexOf(golfer), 1);
        }
        if (this.selected.length == 2) {
            this.pairGolfers();
            this.selected = [];
        }
        this.component.setState(this.produceState());
    };
    return EditMatchSetStore;
}());
exports.EditMatchSetStore = EditMatchSetStore;
//# sourceMappingURL=EditMatchSetStore.js.map