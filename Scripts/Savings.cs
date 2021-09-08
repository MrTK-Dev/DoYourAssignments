using DYA.Scripts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA.Scripts.DATA
{
    public static class Savings
    {
        public static List<CourseModel> DATACACHE = new List<CourseModel>();

        readonly static string FileName = "DYA-Settings.json";

        readonly static string FilePath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FileName
                        );

        public static void SaveToFile()
        {
            List<LocalCourse> localCourses = new List<LocalCourse>();

            for (int i = 0; i < DATACACHE.Count; i++)
            {
                List<LocalAssignment> newAssignmentModels = new List<LocalAssignment>();

                for (int j = 0; j < DATACACHE[j].Assignments.Count; j++)
                {
                    LocalAssignment localAssignment = new LocalAssignment()
                    {
                        Week = DATACACHE[i].Assignments[j].Week,
                        DueTime = DATACACHE[i].Assignments[j].DueTime,
                        Submitted = DATACACHE[i].Assignments[j].Submitted,
                        PointsReached = DATACACHE[i].Assignments[j].PointsReached,
                        PointsMax = DATACACHE[i].Assignments[j].PointsMax
                    };

                    newAssignmentModels.Add(localAssignment);
                }

                LocalCourse localCourse = new LocalCourse()
                {
                    ID = DATACACHE[i].ID,
                    Name = DATACACHE[i].Name,
                    ClassName = DATACACHE[i].ClassName,
                    Weekcount = DATACACHE[i].Weekcount,
                    FirstDue = DATACACHE[i].FirstDue,
                    LowerLimit = DATACACHE[i].LowerLimit,
                    GoalKind = DATACACHE[i].GoalKind,
                    GoalPercentage = DATACACHE[i].GoalPercentage,
                    GoalDiscard = DATACACHE[i].GoalDiscard,

                    Assignments = newAssignmentModels
                };

                localCourses.Add(localCourse);
            }

            LocalData localData = new LocalData
            {
                Courses = localCourses
            };

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(localData, Formatting.Indented));
        }

        public static void LoadFromFile()
        {
            if (!File.Exists(FilePath))
                SaveToFile();

            LocalData newlocalData = JsonConvert.DeserializeObject<LocalData>(
                File.ReadAllText(FilePath)
                );

            List<CourseModel> newCourses = new List<CourseModel>();

            for (int i = 0; i < newlocalData.Courses.Count; i++)
            {
                List<AssignmentModel> newAssignmentModels = new List<AssignmentModel>();

                for (int j = 0; j < newlocalData.Courses[j].Assignments.Count; j++)
                {
                    AssignmentModel newAssignmentModel = new AssignmentModel()
                    {
                        Week = newAssignmentModels[j].Week,
                        DueTime = newAssignmentModels[j].DueTime,
                        Submitted = newAssignmentModels[j].Submitted,
                        PointsReached = newAssignmentModels[j].PointsReached,
                        PointsMax = newAssignmentModels[j].PointsMax
                    };

                    newAssignmentModels.Add(newAssignmentModel);
                }

                CourseModel newCourse = new CourseModel()
                {
                    ID = newlocalData.Courses[i].ID,
                    Name = newlocalData.Courses[i].Name,
                    ClassName = newlocalData.Courses[i].ClassName,
                    Weekcount = newlocalData.Courses[i].Weekcount,
                    FirstDue = newlocalData.Courses[i].FirstDue,
                    LowerLimit = newlocalData.Courses[i].LowerLimit,
                    GoalKind = newlocalData.Courses[i].GoalKind,
                    GoalPercentage = newlocalData.Courses[i].GoalPercentage,
                    GoalDiscard = newlocalData.Courses[i].GoalDiscard,

                    Assignments = newAssignmentModels
                };

                newCourses.Add(newCourse);
            }

            DATACACHE = newCourses;
        }
    }

    [System.Serializable]
    public class LocalData
    {
        public List<LocalCourse> Courses { get; set; } = new List<LocalCourse>();
    }

    [System.Serializable]
    public class LocalCourse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }

        public int Weekcount { get; set; }
        public DateTime FirstDue { get; set; }
        public int LowerLimit { get; set; }

        public Helpers.GoalKind GoalKind { get; set; }
        public float GoalPercentage { get; set; }
        public Helpers.GoalDiscard GoalDiscard { get; set; }

        public List<LocalAssignment> Assignments { get; set; } = new List<LocalAssignment>();
    }

    [System.Serializable]
    public class LocalAssignment
    {
        public int Week { get; set; }
        public DateTime DueTime { get; set; }
        public bool Submitted { get; set; }
        public float PointsReached { get; set; }
        public float PointsMax { get; set; }
    }
}
