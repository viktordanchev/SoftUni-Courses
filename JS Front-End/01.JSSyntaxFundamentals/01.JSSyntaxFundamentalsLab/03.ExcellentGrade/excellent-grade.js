function checkGrade(grade) {
    let output = 'Excellent';

    if (grade < 5.50) {
        output = 'Not excellent';
    }

    console.log(output);
}

checkGrade(5.49);