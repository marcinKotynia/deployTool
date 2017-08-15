# DeployTool

Dead simple solution for Continuous Integration Environment on Windows Machine.
How it works.

- Install Deploy Tool on yor server.
- When you  commit ( publish release ... )
- DeployTool Will trigger command from your configuration


## Prerequisites

- Windows Machine  (Windows Server , Windows 10)
- GIT https://git-scm.com/
- Github Account (applies also to Bitbucket, Gitlab others that supports WeebHook)

# DeployTool - How To setup simple CI using Github weebhooks and  deploymentKey on Windows Machine with IIS

## Step 1 Create ssh certificate - server

~~~
ssh-keygen -t rsa 
~~~

You might need to start ssh-agent before you run the ssh-add command:
~~~
eval `ssh-agent -s`
key ssh-add ~/.ssh/id_rsa
~~~

## Step 2 setup deployment key - Github

- Go to Github > Project > Settings > Deploy Key > Add deployment Keys
- Copy public key (if you are administrator) C:\Users\Administrator\.ssh\id_rsa.pub and paste in Github key

## Step 3 Git Clone repository (USING SSL version)

~~~
git clone git@github.com:marcinKotynia/platforma-deploy.git

replace [marcinKotynia/platforma-deploy] with you repository
~~~

## Step 4 Windows Machine - IIS Install DeployTool 

## Step 5 Windows Machine - IIS Configure DeployTool  must be visible in Internet

## Step 6 Windows Machine - IIS Application pool >  User Profile

Goto Application pool in context which deployTool works.
Set option:  Load User Profile to True on Application Pool

## Step 7 Windows Machine - copy ssh keys

goto C:\Users\[you appllication pool name]   copy newly created key .ssh

## Step 8 Github Setup Weebhook address for DeployTool

Github > Repository > Settings > Webhooks https://github.com/[username]/[repository]/settings/hooks
Add url when DeployTool is installed

## Step 9  Windows Machine - DeployTool Confguration

Find Config.yaml and replace with your project location

~~~
- repositoryName: platforma
  repositoryPath: C:\data\deploy\instance\platforma.bat
~~~

Create batch file C:\data\deploy\instance\platforma.bat
For simple pull just paste below (change your path and names to valid ones)

Command is available under

- yourdomain.com\command\platforma 
- yourdomain.com\command\[your repositoryname]

~~~
set PATH=%PATH%;C:\Program Files\Git\bin;
cd C:\data\platforma-deploy
git pull
~~~


## Step 10 Windows Machine - Assign rights for ApplicationPool to folder where your repository is

If you application pool is named "DefaultAppPool" (just replace this text below if it is named differently)

Open Windows Explorer
Select a file or directory.
Right click the file and select "Properties"
Select the "Security" tab
Click the "Edit" and then "Add" button
Click the "Locations" button and make sure you select the local machine. (Not the Windows domain if the server belongs to one.)
Enter "IIS AppPool\DefaultAppPool" in the "Enter the object names to select:" text box. (Don't forget to change "DefaultAppPool" here to whatever you named your application pool.)
Click the "Check Names" button and click "OK".

