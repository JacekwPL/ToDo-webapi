class ValidationError extends Error {
    constructor(message) {
      super(message);
      this.name = 'ValidationError';
    }
  }

document.addEventListener("DOMContentLoaded", async () => {
    const inputButton = document.querySelector('input.add-item-button')

    inputButton.addEventListener('click', addTask);

    await showTasks();
    updateButtons();
});

function showOutputMessage(type = 'clear', message = "a") {

    const errorMessage = document.getElementById('output-message');
    const inputElement = document.querySelector('.add-item-text');
    errorMessage.style.visibility = 'visible';
    inputElement.style.borderColor = 'black';
    
    if (type === 'success') {
        errorMessage.style.color = 'lime';
        errorMessage.textContent = `${message}`;
    }
    else if (type === 'error' || type === 'userError') {
        errorMessage.style.color = 'red';
        errorMessage.textContent = `Błąd: ${message}`;

        if (type === 'userError') {
            inputElement.style.borderColor = 'red';
        }
    }
    else if (type === 'clear') {
        errorMessage.style.visibility = 'hidden';
    }
}

async function showTasks() {
    const url = 'http://localhost:5017/GetAllTasks';
    try {
        const data = await fetchData(url);
        
        const ulElement = document.getElementById('main-list');
        while (ulElement.firstChild) {
            ulElement.removeChild(ulElement.firstChild);
        }

        data.forEach(element => {
            const id = element.id;
            const nazwa = element.topic;
            const isComplite = element.isComplite;

            addTodoElement(id, nazwa, isComplite);
        });

        updateButtons();
    }
    catch (err) {
        console.error(`Błąd w wyświetlaniu: ${err.message}`);
        showOutputMessage('error', err.message);
    }
}

/**
 * @param {MouseEvent} ev
 */

function addTodoElement(id, name, completed) {

    const mainList = document.getElementById('main-list');

    const newLi = document.createElement('li');

    newLi.setAttribute('data-id', id);
    newLi.setAttribute('data-completed', completed);

    const nameDiv = document.createElement('div');
    nameDiv.classList.add('todo-element-name');
    nameDiv.textContent = name;

    const iconsDiv = document.createElement('div');
    iconsDiv.classList.add('icons');

    const checkSpan = document.createElement('span');
    checkSpan.classList.add('icon', 'check');
    if (!completed) checkSpan.textContent = '🔘';
    else checkSpan.textContent = '✅';

    const deleteSpan = document.createElement('span');
    deleteSpan.classList.add('icon', 'delete');
    deleteSpan.textContent = '🗑️';

    iconsDiv.appendChild(checkSpan);
    iconsDiv.appendChild(deleteSpan);

    newLi.appendChild(nameDiv);
    newLi.appendChild(iconsDiv);

    mainList.appendChild(newLi);
}

async function addTask(ev) {
    ev.preventDefault();
    console.log("Dodaj");

    const url = 'http://localhost:5017/CreateTask';
    const method = 'POST';
    const newTask = document.querySelector('input.add-item-text').value;
    try {
        if (newTask === '') {
            throw new ValidationError('Wartość nie może być pusta');
        }
        const body = {
            topic: newTask,
            isComplite: false,
        };
        
        await fetchData(url, method, body);

        showOutputMessage('success', `Dodano: ${newTask}`);

        await showTasks();
    }
    catch (err) {
        console.error(`Błąd w dodawaniu aktywności: ${err.message}`);
        if (err instanceof ValidationError) {
            showOutputMessage('userError', err.message);
        }
        else {
            showOutputMessage('error', err.message);
        }
    }
}

/**
 * @param {MouseEvent} ev
 */

async function deleteTask(ev, id, deletedTask) {
    ev.stopPropagation();

    const url = `http://localhost:5017/DeleteTask/${id}`;
    const method = 'DELETE';
    const body = id; // Pozmieniać
    try {
        const data = await fetchData(url, method, body);

        // Wyświetlić komunikat o usunięciu

        showOutputMessage('success', `Usunięto ${deletedTask}`);

        showTasks();
    }
    catch (err) {
        console.error(`Błąd w usuwaniu aktywności: ${err.message}`);
        showOutputMessage('error', err.message);
    }
    console.log("Usuń");
}

/**
 * @param {MouseEvent} ev
 */

async function checkTask(ev, id) {
    const url = `http://localhost:5017/MarkAsDone/${id}`;
    const method = 'PUT';
    try {
        await fetchData(url, method);

        // Wyświetlić komunikat o usunięciu

        showOutputMessage('success', 'Potwierdzono ukończenie zadania');

        await showTasks();
    }
    catch (err) {
        console.error(`Błąd podczas zaznaczania aktywności: ${err.message}`);
        showOutputMessage('error', err.message);
    }

    console.log("Zaznacz/Odznacz");
}
