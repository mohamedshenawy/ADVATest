function CreateDepartment() {
    let obj = CollectData();
    let url = "";
    if (obj.Id > 0) {
        url = "/department/UpdateDepartment";
    }
    else {
        url = `/department/AddDepartment`;
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
                    window.location.href = "/department/index"
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
        "DepartmentManagerId":""
    };
    var IdInput = document.querySelector("#DepartmentId");
    var NameInput = document.querySelector("#Name");
    var departmentManagerId = document.querySelector("#DepartmentManagerId");
    obj["Id"] = IdInput.value > 0 ? parseInt(IdInput.value):0;
    obj["Name"] = NameInput.value;
    obj["DepartmentManagerId"] = departmentManagerId !=null ? departmentManagerId.value:null;
    return obj;
}

function OpenDeletePopup(Id) {
    Swal.fire({
        title: "Are you sure to delete this item?",
        text: "if this department has employees , if it deleted then employees will be deleted",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Delete"
    }).then((result) => {
        if (result.isConfirmed) {
            var apiUrl = `/Department/delete/${Id}`;

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

var forms = document.querySelectorAll('.needs-validation')
Array.prototype.slice.call(forms)
    .forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault();
            if (!form.checkValidity()) {
                form.classList.add('was-validated')
                event.stopPropagation();
            } else {
                CreateDepartment();
            }

        });
    })

function OpenAssginManagerPopup(departmentId) {
    let temp = document.getElementsByTagName("template")[0];
    let clon = temp.content.cloneNode(true);

    var popupContent = document.querySelector(".modal-body");
    popupContent.appendChild(clon);
}

