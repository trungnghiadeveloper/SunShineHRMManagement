function sendMessage() {
    var message = document.getElementById("messageInput").value.trim();
    if (message !== '') {
        displayMessage(message, true);
        document.getElementById("messageInput").value = '';

        // Send message to the server (replace with your endpoint)
        // Example using fetch API
        fetch('/api/chat/sendmessage', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ message: message })
        })
            .then(response => response.json())
            .then(data => {
                displayMessage(data, false);
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

// Function to display message in the chatbox
function displayMessage(message, isUser) {
    var chatbox = document.getElementById("chatbox");
    var messageElement = document.createElement("div");
    messageElement.className = isUser ? "user-message" : "bot-message";
    messageElement.textContent = message;
    chatbox.appendChild(messageElement);
    chatbox.scrollTop = chatbox.scrollHeight;
}

// Event listener for send button click
document.getElementById("sendButton").addEventListener("click", sendMessage);

// Event listener for Enter key press in the input field
document.getElementById("messageInput").addEventListener("keypress", function (event) {
    if (event.key === "Enter") {
        sendMessage();
    }
});