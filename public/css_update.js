function updateButtons() {
    const deleteButtons = document.querySelectorAll('span.icon.delete');

    deleteButtons.forEach(button => {
        const id = button.parentElement.parentElement.getAttribute("data-id");
        const deletedTask = button.parentElement.parentElement.textContent.slice(0, -5);

        button.addEventListener('click', (ev) => deleteTask(ev, id, deletedTask));

        const checkButton = button.parentElement.querySelector('span.icon.check');

        button.addEventListener('mouseenter', (ev) => {
            checkButton.classList.remove('highlighted');

            button.classList.add('highlighted');
        });

        button.addEventListener('mouseleave', (ev) => {
            checkButton.classList.add('highlighted');

            button.classList.remove('highlighted');
        });
    });

    hoverUpdate();
}


function hoverUpdate() {
    liElements = document.querySelectorAll('li');

    liElements.forEach(li => {
        const divElement = li.querySelector('div.icons span.icon.check');
        const id = li.getAttribute("data-id");
        li.addEventListener('mouseenter', () => {
                divElement.classList.add('highlighted');
        });
        
        li.addEventListener('mouseleave', () => {
            divElement.classList.remove('highlighted');
        });

        li.addEventListener('click', (ev) => checkTask(ev, id));
    });

}