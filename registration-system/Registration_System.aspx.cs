using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Registration_System : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CourseRegistrationPanel.Visible = true;
            CourseConfirmationPanel.Visible = false;
            ErrorMessage.Visible = false;

            RadioButtonListStudentType.Items.Add(new ListItem("Full Time"));
            RadioButtonListStudentType.Items.Add(new ListItem("Part Time"));
            RadioButtonListStudentType.Items.Add(new ListItem("Co-op"));

            List<Course> courses = Helper.GetCourses();
            for (int i = 0; i < courses.Count(); i++)
            {
                CheckBoxListCourses.Items.Add(new ListItem(courses[i].ToString(), i.ToString()));
            }
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(StudentName.Text))
            {
                List<Course> courses = Helper.GetCourses();
                Student student;

                if (RadioButtonListStudentType.SelectedValue.Any())
                    switch (RadioButtonListStudentType.SelectedItem.Value)
                    {
                        case "Full Time":
                            student = new FullTimeStudent(StudentName.Text);
                            break;
                        case "Part Time":
                            student = new PartTimeStudent(StudentName.Text);
                            break;
                        case "Co-op":
                            student = new CoopStudent(StudentName.Text);
                            break;
                        default:
                            student = new FullTimeStudent(StudentName.Text);
                            break;
                    }
                else
                    throw new Exception("Please select the student's status (full‑time, part‑time, co-op).");

                if (CheckBoxListCourses.SelectedValue.Any())
                {
                    foreach (ListItem item in CheckBoxListCourses.Items)
                    {
                        if (item.Selected)
                        {
                            int courseNumber = int.Parse(item.Value);
                            student.addCourse(courses[courseNumber]);
                            ErrorMessage.Visible = false;
                        }
                    }
                }
                else
                    throw new Exception("Please select the course.");

                // Course Confirmation Panel:
                CourseRegistrationPanel.Visible = false;
                CourseConfirmationPanel.Visible = true;

                ConfirmationMessage1.Text = string.Format("Thank you {0} for using our online registration system.", student.Name);
                ConfirmationMessage2.Text = string.Format("You have been registered as a {0} for the following courses:", student.ToString());

                foreach (Course course in student.getEnrolledCourses())
                {
                    TableRow tableRow = new TableRow();
                    TableCell tableCourseCode = new TableCell();
                    TableCell tabledCourseTitle = new TableCell();
                    TableCell tableWeeklyHours = new TableCell();
                    TableCell tableFeePayable = new TableCell();

                    tableCourseCode.Text = course.Code;
                    tableRow.Cells.Add(tableCourseCode);
                    tabledCourseTitle.Text = course.Title;
                    tableRow.Cells.Add(tabledCourseTitle);
                    tableWeeklyHours.Text = course.WeeklyHours.ToString();
                    tableRow.Cells.Add(tableWeeklyHours);
                    tableFeePayable.Text = "$" + course.Fee.ToString();
                    tableRow.Cells.Add(tableFeePayable);
                    ConfirmationTable.Rows.Add(tableRow);
                }

                TableFooterRow tableFooterRow = new TableFooterRow();
                TableCell tableTotal = new TableCell();
                TableCell tableTotalWeeklyHours = new TableCell();
                TableCell tableTotalFeePayable = new TableCell();

                tableTotal.ColumnSpan = 2;

                tableTotal.Text = "Total:";
                tableTotalWeeklyHours.Text = student.totalWeeklyHours().ToString();
                tableTotalFeePayable.Text = "$" + student.feePayable().ToString();

                tableFooterRow.Cells.Add(tableTotal);
                tableFooterRow.Cells.Add(tableTotalWeeklyHours);
                tableFooterRow.Cells.Add(tableTotalFeePayable);

                ConfirmationTable.Rows.Add(tableFooterRow);
            }
            else
                throw new Exception("Please enter student name.");
        }

        catch (Exception ex)
        {
            ErrorMessage.Visible = true;
            ErrorMessage.Text = ex.Message;
        }
    }
}