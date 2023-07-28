function attachEvents() {
  const url = "http://localhost:3030/jsonstore/collections/students";
  const tbody = document.querySelector("#results tbody");

  document.getElementById("submit").addEventListener("click", submit);

  function submit() {
    const firstName = document.getElementsByName("firstName")[0].value;
    const lastName = document.getElementsByName("lastName")[0].value;
    const facultyNumber = document.getElementsByName("facultyNumber")[0].value;
    const grade = document.getElementsByName("grade")[0].value;

    if (firstName && lastName && facultyNumber && grade) {
      addStudentToData({
        firstName: firstName,
        lastName: lastName,
        facultyNumber: facultyNumber,
        grade: grade,
      });
    }

    Array.from(document.querySelectorAll(".inputs input")).forEach(
      (input) => (input.value = "")
    );

    tbody.innerHTML = "";
    fillTheTable();
  }

  async function addStudentToData(student) {
    await fetch(url, {
      method: "POST",
      body: JSON.stringify(student),
    });
  }

  async function fillTheTable() {
    fetch(url)
      .then((res) => res.json())
      .then((res) => {
        for (const key in res) {
          const tr = tbody.appendChild(document.createElement("tr"));
          const student = res[key];

          for (const key in student) {
            if (key !== "_id") {
              tr.appendChild(document.createElement("td")).textContent =
                student[key];
            }
          }
        }
      });
  }
}

attachEvents();
