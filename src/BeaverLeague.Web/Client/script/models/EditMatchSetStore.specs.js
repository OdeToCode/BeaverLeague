"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("React");
var models_1 = require("models");
var FakeComponent = /** @class */ (function (_super) {
    __extends(FakeComponent, _super);
    function FakeComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    FakeComponent.prototype.setState = function (data) { };
    return FakeComponent;
}(React.Component));
describe("The matchset editor", function () {
    var golfers;
    var matchSet;
    beforeEach(function () {
        golfers = [
            { id: 1, firstName: "A", lastName: "A", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 2, firstName: "B", lastName: "B", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 3, firstName: "C", lastName: "C", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 4, firstName: "D", lastName: "D", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 5, firstName: "E", lastName: "E", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 6, firstName: "F", lastName: "F", membershipId: "", handicap: 0, isAdmin: false, isActive: true }
        ];
        matchSet = {
            id: 1,
            seasonId: 1,
            matchSetNumber: 1,
            matches: [
                { id: 10, golferA: golfers[0], golferB: golfers[1] }
            ],
            inactives: [
                { id: 1, matchSetId: 1, golferId: 3 }
            ]
        };
    });
    it("should organize view model", function () {
        var ems = new models_1.EditMatchSetStore(new FakeComponent({}));
        ems.arrangeData(golfers, matchSet);
        expect(ems.inactives.length).toBe(1);
        expect(ems.inactives[0].firstName).toBe("C");
        expect(ems.matchset.matches.length).toBe(1);
        expect(ems.matchset.matches[0].golferA.id).toBe(1);
        expect(ems.golfers.length).toBe(3);
    });
    it("should select a golfer", function () {
        var ems = new models_1.EditMatchSetStore(new FakeComponent({}));
        ems.arrangeData(golfers, matchSet);
        ems.selectGolfer(ems.golfers[1]);
        expect(ems.golfers[1].isSelected).toBe(true);
    });
    it("should pair golfers when 2 golfers selected", function () {
        var ems = new models_1.EditMatchSetStore(new FakeComponent({}));
        ems.arrangeData(golfers, matchSet);
        ems.selectGolfer(ems.golfers[2]);
        ems.selectGolfer(ems.golfers[0]);
        expect(ems.golfers.length).toBe(1);
        expect(ems.golfers[0].firstName).toBe("E");
        expect(ems.matchset.matches.length).toBe(2);
        expect(ems.matchset.matches[1].golferA.firstName).toBe("F");
        expect(ems.matchset.matches[1].golferB.firstName).toBe("D");
        expect(ems.matchset.matches[1].id).toBe(-2);
    });
    it("twice selected golfer undoes selection", function () {
        var ems = new models_1.EditMatchSetStore(new FakeComponent({}));
        ems.arrangeData(golfers, matchSet);
        ems.selectGolfer(ems.golfers[1]);
        ems.selectGolfer(ems.golfers[1]);
        ems.selectGolfer(ems.golfers[1]);
        ems.selectGolfer(ems.golfers[1]);
        expect(ems.golfers.length).toBe(3);
        expect(ems.matchset.matches.length).toBe(1);
        expect(ems.golfers[1].isSelected).toBe(false);
    });
    it("can delete a match", function () {
        var ems = new models_1.EditMatchSetStore(new FakeComponent({}));
        ems.arrangeData(golfers, matchSet);
        ems.deleteMatch(10);
        expect(ems.matchset.matches.length).toBe(0);
        expect(ems.golfers.length).toBe(5);
    });
});
//# sourceMappingURL=EditMatchSetStore.specs.js.map