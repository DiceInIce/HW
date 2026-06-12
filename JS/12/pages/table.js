const table = document.querySelector('.table');
const thBox = table.querySelector('thead');
const tbody = table.querySelector('tbody');

thBox.addEventListener('click', function(event) {
    const th = event.target.closest('th');
    if (!th) return;

    const columnIndex = th.cellIndex;
    const type = th.getAttribute('data-type');
    
    const rowsArray = Array.from(tbody.rows);

    let compare;
    if (type === 'number') {
        compare = (rowA, rowB) => {
            const valA = Number(rowA.cells[columnIndex].textContent);
            const valB = Number(rowB.cells[columnIndex].textContent);
            return valA - valB;
        };
    } else {
        compare = (rowA, rowB) => {
            const valA = rowA.cells[columnIndex].textContent;
            const valB = rowB.cells[columnIndex].textContent;
            return valA.localeCompare(valB);
        };
    }

    rowsArray.sort(compare);

    tbody.append(...rowsArray);
});
