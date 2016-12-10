export function parameters(element: HTMLElement) {
    var value = element.getAttribute("data-parameters");
    if (value) {
        return JSON.parse(value);
    }
    return null;
}