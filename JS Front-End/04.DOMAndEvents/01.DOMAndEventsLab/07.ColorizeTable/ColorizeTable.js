function colorize() {
  const rows = Array.from(
    document.querySelectorAll("table tr:nth-child(even)")
  ).forEach((row) => (row.bgColor = "teal"));
}
