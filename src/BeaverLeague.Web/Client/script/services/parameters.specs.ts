import {parameters} from "./parameters";

describe("the parameters helper", () => {

    it("should deserialize data-parameters", () => {
        var e = document.createElement("div");
        e.setAttribute("data-parameters", JSON.stringify({name:"Scott"}));

        var result = parameters(e);
        expect(result.name).toBe("Scott");
    });

});