function CreateEmployee() {
    let obj = CollectData();
    let url = "";
    if (obj.Id > 0) {
        url = "/employee/Updateemployee";
    }
    else {
        url = `/employee/Addemployee`;
    }

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    })
        .then(response => response.json())
        .then(data => {
            Swal.fire({
                position: "center-center",
                icon: "success",
                title: "Your item has been saved",
                showConfirmButton: true
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = "/employee/index"
                }
            });

        })
        .catch(error => {
            Swal.fire({
                position: "center-center",
                icon: "error",
                title: error,
                showConfirmButton: true,
                timer: 1500
            });
        });

}

function CollectData() {
    var obj = {
        "Id": 0,
        "Name": "",
        "Salary": "",
        "IsManager": false,
        "ManagerId": 0,
        "DepartmentId": 0
    };
    var IdInput = document.querySelector("#EmployeeId");
    var NameInput = document.querySelector("#Name");
    var salaryInput = document.querySelector("#Salary");
    var IsManagerCheckbox = document.querySelector("#IsManager");
    var departmentId = document.querySelector("#DepartmentId");
    var managerId = document.querySelector("#ManagerId");
    obj["Id"] = IdInput.value > 0 ? parseInt(IdInput.value):0;
    obj["Name"] = NameInput.value;
    obj["Salary"] = parseFloat(salaryInput.value).toFixed(2);
    obj["DepartmentId"] = parseInt(departmentId.value);
    obj["ManagerId"] = parseInt(managerId.value);
    obj["IsManager"] = IsManagerCheckbox.checked == true? true:false;
    return obj;
}

function OpenDeletePopup(Id) {
    Swal.fire({
        title: "Are you sure to delete this item?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Delete"
    }).then((result) => {
        if (result.isConfirmed) {
            var apiUrl = `/Employee/delete/${Id}`;

            fetch(apiUrl)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    Swal.fire({
                        title: "Deleted",
                        text: "item has been deleted.",
                        icon: "success"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.reload();
                        }
                    });
                })
                .catch(error => {
                    Swal.fire({
                        title: "Error",
                        text: error.message || 'An error occurred',
                        icon: "error"
                    });
                });
        }
    });
}
function validateSalary(input) {
    var value = input.value;
    var isValid = parseFloat(value) >= 0 || value == '';

    if (!isValid) {
        input.setCustomValidity('Salary must be a non-negative number.');
    } else {
        input.setCustomValidity('');
    }
}


var forms = document.querySelectorAll('.needs-validation')
Array.prototype.slice.call(forms)
    .forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault();
            if (!form.checkValidity()) {
                form.classList.add('was-validated')
                event.stopPropagation();
            } else {
                CreateEmployee();
            }

        });
    })
