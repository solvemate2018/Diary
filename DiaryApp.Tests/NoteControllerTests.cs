using System.Collections.Generic;
using System.Linq;
using DiaryApp.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Moq;
using DiaryApp.Data;
using DiaryApp.Controllers;
using System;

namespace DiaryApp.Tests
{
    [TestClass]
    public class NoteControllerTests
    {
        [TestMethod]
        public void Save_Note_Tests()
        {
            var notesData = new List<Note>
            {
                new Note("FirstTitle", "FirstText"),
                new Note("SecondTitle", "SecondText"),
                new Note("ThirdTitle", "ThirdText"),
                new Note("FourthTitle", "FourthText")
            }.AsQueryable();

            var mockNoteSet = new Mock<DbSet<Note>>();
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.Provider).Returns(notesData.Provider);
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.Expression).Returns(notesData.Expression);
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.ElementType).Returns(notesData.ElementType);
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.GetEnumerator()).Returns(notesData.GetEnumerator());

            var mockContext = new Mock<DiaryContext>();
            mockContext.Setup(c => c.Notes).Returns(mockNoteSet.Object);

            var service = new NoteController(mockContext.Object);

            Note addingNote = new Note("FirstTitle", "DifferentText");
            Assert.ThrowsException<ArgumentException>(() => service.SaveNote(addingNote.Title, addingNote.Text));

        }

        [TestMethod]
        public void Get_Text_Tests()
        {
            var notesData = new List<Note>
            {
                new Note("FirstTitle", "FirstText"),
                new Note("SecondTitle", "SecondText"),
                new Note("ThirdTitle", "ThirdText"),
                new Note("FourthTitle", "FourthText")
            }.AsQueryable();

            var mockNoteSet = new Mock<DbSet<Note>>();
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.Provider).Returns(notesData.Provider);
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.Expression).Returns(notesData.Expression);
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.ElementType).Returns(notesData.ElementType);
            mockNoteSet.As<IQueryable<Note>>().Setup(m => m.GetEnumerator()).Returns(notesData.GetEnumerator());

            var mockContext = new Mock<DiaryContext>();
            mockContext.Setup(c => c.Notes).Returns(mockNoteSet.Object);

            var service = new NoteController(mockContext.Object);

            Assert.AreEqual("FirstText", service.GetText("FirstTitle"));
            Assert.AreEqual("SecondText", service.GetText("SecondTitle"));
            Assert.AreEqual("ThirdText", service.GetText("ThirdTitle"));
            Assert.AreEqual("FourthText", service.GetText("FourthTitle"));
        }

    }
}