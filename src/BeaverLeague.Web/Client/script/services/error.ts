class ErrorHandler {
    reportError(error: Error) {
        alert(error.message);
    }
    reportMessage(message: string) {
        alert(message);
    }
}

export const errorHandler = new ErrorHandler();