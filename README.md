# DeployTool. How To setup simple CI using Github weebhooks and  deploymentKey on Windows Machine with IIS


## Prerequisites

- Windows Machine  (Windows Server , Windows 10)
- GIT https://git-scm.com/
- Github Account

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

Find Config.yaml and replace with your project loacation

~~~
- repositoryName: platforma
  repositoryPath: C:\git\csvtosql
  username: 
  password: 
~~~

## Step 10 Windows Machine - Rights

Assign rights for ApplicationPool to folder where your repository is

Right click on folder > Goto Security > Edit > add
Add full rights for IIS AppPool\DefaultAppPool  (replace DEfaultAppPool with your app pool name) 
