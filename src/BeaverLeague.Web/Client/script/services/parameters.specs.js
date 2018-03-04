"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var parameters_1 = require("./parameters");
describe("the parameters helper", function () {
    it("should deserialize data-parameters", function () {
        var e = document.createElement("div");
        e.setAttribute("data-parameters", JSON.stringify({ name: "Scott" }));
        var result = parameters_1.parameters(e);
        expect(result.name).toBe("Scott");
    });
});
//# sourceMappingURL=parameters.specs.js.map