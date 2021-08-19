using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class UserFeedbackService : IUserFeedbackService
    {
        IDbHelper dbHelper;
        public UserFeedbackService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        string selectQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Rating]
                                  ,[OpinionText]
                                  ,[ReviewTitle]
                                  ,[TermsAccept]
                                  ,[TimeStamp]
                              FROM [dbo].[UserFeedback]
                                order by UpdatedOn desc";
        string insertQuery = @"INSERT INTO [dbo].[UserFeedback]
                                       ([IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy]
                                       ,[Rating]
                                       ,[OpinionText]
                                       ,[ReviewTitle]
                                       ,[TermsAccept]
                                       ,[TimeStamp])
                                 VALUES
                                       (@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy
                                       ,@Rating
                                       ,@OpinionText
                                       ,@ReviewTitle
                                       ,@TermsAccept
                                       ,@TimeStamp)";
        string updateQuery = @"UPDATE [dbo].[UserFeedback]
                                   SET [IsActive] =@IsActive
                                      ,[CreatedOn] =@CreatedOn
                                      ,[CreatedBy] =@CreatedBy
                                      ,[UpdatedOn] =@UpdatedOn
                                      ,[UpdatedBy] =@UpdatedBy
                                      ,[Rating] =@Rating
                                      ,[OpinionText] =@OpinionText
                                      ,[ReviewTitle] =@ReviewTitle
                                      ,[TermsAccept] =@TermsAccept
                                      ,[TimeStamp]=@TimeStamp
                                 WHERE Id =@Id";
        string selectByIdQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Rating]
                                  ,[OpinionText]
                                  ,[ReviewTitle]
                                  ,[TermsAccept]
                                  ,[TimeStamp]
                              FROM [dbo].[UserFeedback]
                                where id = ";
        string deleteQuery = "Delete from UserFeedback";
        public void Add(IModel model)
        {
     
            var userFeedback = (UserFeedback)model;
            userFeedback.IsActive = true;
            dbHelper.Add(insertQuery, userFeedback);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new UserFeedback { Id = id });
        }

        public IList<UserFeedback> GetAll<UserFeedback>()
        {
            var UserFeedbackList = dbHelper.FetchData<UserFeedback>($"{selectQuery}");
            return UserFeedbackList;
        }

        public IList<UserFeedback> GetById<UserFeedback>(int id)
        {
            var UserFeedbackList = dbHelper.FetchData<UserFeedback>($"{selectByIdQuery}{id}");
            return UserFeedbackList;
        }

        public void Update(IModel model)
        {
            var userFeedback = (UserFeedback)model;
           
            dbHelper.Update(updateQuery, userFeedback);
        }

    }
}
